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
    internal class SQLCreateInterpreter : SQLBaseInterpreter
    {
        public SQLCreateInterpreter(Database db) : base(db) { }

        protected override object InternalVisit(CreateTableStatement node)
        {
            var table = Visit<Table>(node.Definition);
            table.TableName = Visit<string>(node.SchemaObjectName);
            if (Database.ContainsTable(table.TableName))
            {
                var msg = string.Format("There is already an object named '{0}' in the database", table.TableName);
                throw new DuplicateNameException(msg);
            }
            Database.AddTable(table);

            try
            {
                foreach (var cd in node.Definition.ColumnDefinitions)
                {
                    foreach (var constraint in cd.Constraints)
                    {
                        var column = table.GetColumn(cd.ColumnIdentifier.Value);
                        Visit<Action<Table, Column>>(constraint)?.Invoke(table, column);
                    }
                }
                foreach (var constraint in node.Definition.TableConstraints)
                {
                    Visit<Action<Table, Column>>(constraint)?.Invoke(table, null);
                }
            }
            catch
            {
                Database.RemoveTable(table);
                throw;
            }
            return table;
        }

        protected override object InternalVisit(TableDefinition node)
        {
            //TODO: indexes
            var result = new Table(Database);
            var columns = node.ColumnDefinitions
                    .Select(cd => Visit<Column>(cd))
                    .ToArray();
            if (columns.Count(col => col.AutoIncrement) > 1)
            {
                throw new ArgumentException("Only one identity column per table is allowed");
            }
            result.AddColumns(columns);
            return result;
        }

        protected override object InternalVisit(ColumnDefinition node)
        {
            /*
             * TODO(Richo): Computed columns don't necessarily include the datatype, in that case
             * the data type has to be extracted from the computed expression.
             */
            var type = Visit<Type>(node.DataType);
            var column = new Column(node.ColumnIdentifier.Value, type);
            Visit<Action<Column>>(node.IdentityOptions)?.Invoke(column);
            Visit<Action<Column>>(node.DefaultConstraint)?.Invoke(column);
            return column;
        }

        protected override object InternalVisit(IdentityOptions node)
        {
            Action<Column> applier = column =>
            {
                column.AutoIncrementSeed = EvaluateExpression(node.IdentitySeed, Database.GlobalEnvironment, 1);
                column.AutoIncrementStep = EvaluateExpression(node.IdentityIncrement, Database.GlobalEnvironment, 1);
                column.AutoIncrement = true;
            };
            return applier;
        }

        protected override object InternalVisit(DefaultConstraintDefinition node)
        {
            Action<Column> applier = (column) =>
            {
                column.DefaultValue = EvaluateExpression<object>(node.Expression, Database.GlobalEnvironment);
            };
            return applier;
        }

        protected override object InternalVisit(NullableConstraintDefinition node)
        {
            Action<Table, Column> applier = (ign, column) =>
            {
                column.AllowDBNull = node.Nullable;
            };
            return applier;
        }

        protected override object InternalVisit(UniqueConstraintDefinition node)
        {
            Action<Table, Column> applier = (table, column) =>
            {
                var isPK = node.IsPrimaryKey;

                /*
                 * INFO(Richo): We can get the columns from two places: the "column" arg or the node's "Columns" property.
                 * The node's property takes precedence, but it could come empty if the constraint was specified inline.
                 * In those cases we rely on the "column" argument.
                 */
                Column[] columns;
                if (node.Columns == null || node.Columns.Count() == 0)
                {
                    columns = new[] { column };
                }
                else
                {
                    columns = node.Columns
                        .Select(c => table.GetColumn(Visit<string[]>(c.Column.MultiPartIdentifier).Last()))
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

                if (isPK && table.PrimaryKey.Length > 0)
                {
                    var msg = string.Format("Cannot add multiple PRIMARY KEY constraints to table '{0}'", table.TableName);
                    throw new ArgumentException(msg);
                }

                Database.AddConstraint(new UniqueConstraint(name, columns, isPK));
            };
            return applier;
        }

        protected override object InternalVisit(ForeignKeyConstraintDefinition node)
        {
            Action<Table, Column> applier = (table, ignored) =>
            {
                var constraintName = node.ConstraintIdentifier.Value;

                Table refTable;
                {
                    var refTableName = Visit<string>(node.ReferenceTableName);
                    refTable = Database.GetTable(refTableName);
                    if (refTable == null)
                    {
                        var msg = string.Format("Foreign key '{0}' references invalid table '{1}'", constraintName, refTableName);
                        throw new NullReferenceException(msg);
                    }
                }

                Column[] parents = node.ReferencedTableColumns
                    .Select(c =>
                    {
                        var dc = refTable.GetColumn(c.Value);
                        if (dc == null)
                        {
                            var msg = string.Format("Foreign key '{0}' references invalid column '{1}' in referenced table '{2}'",
                                constraintName, c.Value, refTable.TableName);
                            throw new NullReferenceException(msg);
                        }
                        return dc;
                    })
                    .ToArray();

                Column[] children = node.Columns
                    .Select(c =>
                    {
                        var dc = table.GetColumn(c.Value);
                        if (dc == null)
                        {
                            var msg = string.Format("Foreign key '{0}' references invalid column '{1}' in referencing table '{2}'",
                                constraintName, c.Value, table.TableName);
                            throw new NullReferenceException(msg);
                        }
                        return dc;
                    })
                    .ToArray();

                var fk = new ForeignKeyConstraint(constraintName, parents, children);
                fk.DeleteRule = GetDeleteUpdateRule(node.DeleteAction);
                fk.UpdateRule = GetDeleteUpdateRule(node.UpdateAction);
                if ((fk.DeleteRule == Rule.SetNull || fk.UpdateRule == Rule.SetNull)
                    && children.Any(c => !c.AllowDBNull))
                {
                    var msg = string.Format("Cannot create the foreign key \"{0}\" with the SET NULL referential action, " +
                                            "because one or more referencing columns are not nullable.", constraintName);
                    throw new ConstraintException(msg);
                }
                else if ((fk.DeleteRule == Rule.SetDefault || fk.UpdateRule == Rule.SetDefault)
                    && children.Any(c => !c.AllowDBNull && c.DefaultValue == null ))
                {
                    var msg = string.Format("Cannot create the foreign key \"{0}\" with the SET DEFAULT referential action, " +
                                            "because one or more referencing not-nullable columns lack a default constraint.", constraintName);
                    throw new ConstraintException(msg);
                }
                Database.AddConstraint(fk);
            };
            return applier;
        }

        private Rule GetDeleteUpdateRule(DeleteUpdateAction action)
        {
            switch (action)
            {
                case DeleteUpdateAction.Cascade: return Rule.Cascade;
                case DeleteUpdateAction.SetNull: return Rule.SetNull;
                case DeleteUpdateAction.SetDefault: return Rule.SetDefault;

                case DeleteUpdateAction.NotSpecified:
                case DeleteUpdateAction.NoAction:
                default:
                    return Rule.None;
            }
        }
    }
}
