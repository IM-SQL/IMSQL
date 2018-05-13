using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    /// <summary>
    /// This class implements the methods necesary to execute a create table statement
    /// </summary>
    internal class SQLCreateInterpreter : SQLVisitor
    {
        public SQLCreateInterpreter(DataSet ds) : base(ds) {}

        public override void ExplicitVisit(CreateTableStatement node)
        {
            /*
             * HACK(Richo): Here I visit the table constraints making sure foreign keys are applied
             * last. The reason for this is that foreing key constraints automatically add an unique
             * constraint to the referenced table if one is not already added. Normally, that shouldn't
             * be a problem because the referenced table should already be created by the time we add
             * the foreign key but if the foreign key points to the same table then we could have a 
             * problem because the primary key could not yet be configured. In that case, the foreign
             * key would add a unique constraint and then the primary key won't be allowed. A better
             * solution could probably be to replace the existing unique constraint when adding the 
             * primary key but that would also mean to temporarily remove the foreign key, otherwise
             * the unique constraint won't be removed. I don't know, it seemed like a lot of work so
             * I went in this direction but I know I'll probably have to fix it eventually...
             */
            var foreignKeyConstraints = node.Definition.TableConstraints
                .Where(c => c is ForeignKeyConstraintDefinition);
            foreach (var constraint in foreignKeyConstraints)
            {
                constraint.Accept(this);
            }
            var tableConstraints = node.Definition.TableConstraints
                .Where(c => !(c is ForeignKeyConstraintDefinition));
            foreach (var constraint in tableConstraints)
            {
                constraint.Accept(this);
            }

            var columnConstraints = node.Definition.ColumnDefinitions
                .SelectMany(cd => cd.Constraints)
                .Reverse();
            foreach (var constraint in columnConstraints)
            {
                constraint.Accept(this);
            }

            node.SchemaObjectName.Accept(this);
            node.Definition.Accept(this);
            Visit(node);            
        }

        public override void Visit(CreateTableStatement node)
        {
            //TODO: creation errors? what if the name is taken?
            DataTable table = pop<DataTable>();
            table.TableName = pop<string>();
            ds.Tables.Add(table);

            foreach (var cd in node.Definition.ColumnDefinitions)
            {
                for (int i = 0; i < cd.Constraints.Count; i++)
                {
                    var column = table.Columns[cd.ColumnIdentifier.Value];
                    pop<Action<DataTable, DataColumn>>()?.Invoke(table, column);
                }
            }
            for (int i = 0; i < node.Definition.TableConstraints.Count; i++)
            {
                pop<Action<DataTable, DataColumn>>()?.Invoke(table, null);
            }
            push(table);
        }

        public override void ExplicitVisit(TableDefinition node)
        {
            //TODO: indexes
            foreach (var definition in node.ColumnDefinitions)
            {
                definition.Accept(this);
            }
            Visit(node);
        }

        public override void Visit(TableDefinition node)
        {
            DataColumn[] columns = new DataColumn[node.ColumnDefinitions.Count];
            for (int i = node.ColumnDefinitions.Count - 1; i >= 0; i--)
            {
                columns[i] = pop<DataColumn>();
            }
            var result = new DataTable();
            result.Columns.AddRange(columns);

            push(result);
        }

        public override void ExplicitVisit(ColumnDefinition node)
        {
            //if i dont override this it tries to call visit columndefinitionbase
            //TODO: collation? other childs?
            node.DefaultConstraint?.Accept(this);
            node.IdentityOptions?.Accept(this);
            node.DataType.Accept(this);
            Visit(node);
        }

        public override void Visit(ColumnDefinition node)
        {
            var type = pop<Type>();
            var column = new DataColumn(node.ColumnIdentifier.Value, type);
            if (node.IdentityOptions != null)
            {
                pop<Action<DataColumn>>()(column);
            }
            if (node.DefaultConstraint != null)
            {
                pop<Action<DataColumn>>()(column);
            }
            push(column);
        }

        public override void ExplicitVisit(IdentityOptions node)
        {
            if (node.IdentitySeed == null) { push(1); }
            else { node.IdentitySeed.Accept(this); }

            if (node.IdentityIncrement == null) { push(1); }
            else { node.IdentityIncrement?.Accept(this); }

            Visit(node);
        }

        public override void Visit(IdentityOptions node)
        {
            Action<DataColumn> applier = column =>
            {
                int step = pop<int>();
                int seed = pop<int>();
                column.AutoIncrement = true;
                column.AutoIncrementSeed = seed;
                column.AutoIncrementStep = step;
            };
            push(applier);
        }

        public override void ExplicitVisit(DefaultConstraintDefinition node)
        {
            //TODO: i think if the default value is a function this might have to be reviewed
            node.Expression.Accept(this);
            Visit(node);
        }

        public override void Visit(DefaultConstraintDefinition node)
        {
            Action<DataColumn> applier = (column) =>
            {
                object value = pop<object>();
                column.DefaultValue = value;
            };
            push(applier);
        }

        public override void ExplicitVisit(NullableConstraintDefinition node)
        {
            Visit(node);
        }

        public override void Visit(NullableConstraintDefinition node)
        {
            Action<DataTable, DataColumn> applier = (ign, column) =>
            {
                column.AllowDBNull = node.Nullable;
            };
            push(applier);
        }

        public override void ExplicitVisit(UniqueConstraintDefinition node)
        {
            Visit(node);
        }

        public override void Visit(UniqueConstraintDefinition node)
        {
            Action<DataTable, DataColumn> applier = (table, column) =>
            {
                var isPK = node.IsPrimaryKey;

                /*
                 * INFO(Richo): We can get the columns from two places: the "column" arg or the node's "Columns" property.
                 * The node's property takes precedence, but it could come empty if the constraint was specified inline.
                 * In those cases we rely on the "column" argument.
                 */
                DataColumn[] columns;
                if (node.Columns == null || node.Columns.Count == 0)
                {
                    columns = new[] { column };
                }
                else
                {
                    columns = node.Columns
                        .Select(c => table.Columns[c.Column.MultiPartIdentifier[0].Value])
                        .ToArray();
                }

                var name = node.ConstraintIdentifier?.Value;
                if (string.IsNullOrWhiteSpace(name))
                {
                    string id = string.Join("", Guid.NewGuid().ToByteArray().Select(b => b.ToString("X2")));
                    if (isPK)
                    {
                        name = string.Format("PK_{0}_{1}", table.TableName, id);
                    }
                    else
                    {
                        name = string.Format("UC_{0}_{1}_{2}", table.TableName,
                            string.Join("_", columns.Select(c => c.ColumnName)), id);
                    }
                }

                table.Constraints.Add(new UniqueConstraint(name, columns, isPK));
            };
            push(applier);
        }

        public override void ExplicitVisit(ForeignKeyConstraintDefinition node)
        {
            node.ReferenceTableName.Accept(this);
            Visit(node);
        }

        public override void Visit(ForeignKeyConstraintDefinition node)
        {
            Action<DataTable, DataColumn> applier = (table, ignored) =>
            {
                var constraintName = node.ConstraintIdentifier.Value;

                DataTable refTable;
                {
                    var refTableName = pop<string>();
                    refTable = ds.Tables[refTableName];
                    if (refTable == null)
                    {
                        var msg = string.Format("Foreign key '{0}' references invalid table '{1}'", constraintName, refTableName);
                        throw new NullReferenceException(msg);
                    }
                }

                DataColumn[] parents = node.ReferencedTableColumns
                    .Select(c => 
                    {
                        var dc = refTable.Columns[c.Value];
                        if (dc == null)
                        {
                            var msg = string.Format("Foreign key '{0}' references invalid column '{1}' in referenced table '{2}'",
                                constraintName, c.Value, refTable.TableName);
                            throw new NullReferenceException(msg);
                        }
                        return dc;
                    })
                    .ToArray();

                DataColumn[] childs = node.Columns
                    .Select(c => 
                    {
                        var dc = table.Columns[c.Value];
                        if (dc == null)
                        {
                            var msg = string.Format("Foreign key '{0}' references invalid column '{1}' in referencing table '{2}'",
                                constraintName, c.Value, table.TableName);
                            throw new NullReferenceException(msg);
                        }
                        return dc;
                    })
                    .ToArray();

                var fk = new ForeignKeyConstraint(constraintName, parents, childs);
                table.Constraints.Add(fk);
            };
            push(applier);
        }
    }
}
