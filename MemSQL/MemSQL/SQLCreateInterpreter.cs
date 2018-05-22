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
        public SQLCreateInterpreter(DataSet ds) : base(ds) { }

        protected override object InternalVisit(CreateTableStatement node)
        {
            var table = Visit<DataTable>(node.Definition);
            table.TableName = Visit<string>(node.SchemaObjectName);
            if (ds.Tables.Contains(table.TableName))
            {
                var msg = string.Format("There is already an object named '{0}' in the database", table.TableName);
                throw new DuplicateNameException(msg);
            }
            ds.Tables.Add(table);

            try
            {
                foreach (var cd in node.Definition.ColumnDefinitions)
                {
                    foreach (var constraint in cd.Constraints)
                    {
                        var column = table.Columns[cd.ColumnIdentifier.Value];
                        Visit<Action<DataTable, DataColumn>>(constraint)?.Invoke(table, column);
                    }
                }
                foreach (var constraint in node.Definition.TableConstraints)
                {
                    Visit<Action<DataTable, DataColumn>>(constraint)?.Invoke(table, null);
                }
            }
            catch
            {
                ds.Tables.Remove(table);
                throw;
            }
            return table;
        }

        protected override object InternalVisit(TableDefinition node)
        {
            //TODO: indexes
            var result = new DataTable();
            var columns = node.ColumnDefinitions
                    .Select(cd => Visit<DataColumn>(cd))
                    .ToArray();
            if (columns.Count(col => col.AutoIncrement) > 1)
            {
                throw new ArgumentException("Only one identity column per table is allowed");
            }
            result.Columns.AddRange(columns);
            return result;
        }

        protected override object InternalVisit(ColumnDefinition node)
        {
            /*
             * TODO(Richo): Computed columns don't necessarily include the datatype, in that case
             * the data type has to be extracted from the computed expression.
             */
            var type = Visit<Type>(node.DataType);
            var column = new DataColumn(node.ColumnIdentifier.Value, type);
            Visit<Action<DataColumn>>(node.IdentityOptions)?.Invoke(column);
            Visit<Action<DataColumn>>(node.DefaultConstraint)?.Invoke(column);
            return column;
        }

        protected override object InternalVisit(IdentityOptions node)
        {
            Action<DataColumn> applier = column =>
            {
                // TODO(Richo): Use the global environment here or what? For now, I'm using null...
                column.AutoIncrementSeed = (int)Visit<Func<Environment, object>>(node.IdentitySeed, env => 1)(null);
                column.AutoIncrementStep = (int)Visit<Func<Environment, object>>(node.IdentityIncrement, env => 1)(null);
                column.AutoIncrement = true;
            };
            return applier;
        }

        protected override object InternalVisit(DefaultConstraintDefinition node)
        {
            Action<DataColumn> applier = (column) =>
            {
                // TODO(Richo): Use the global environment here or what? For now, I'm using null...
                column.DefaultValue = Visit<Func<Environment, object>>(node.Expression)(null);
            };
            return applier;
        }

        protected override object InternalVisit(NullableConstraintDefinition node)
        {
            Action<DataTable, DataColumn> applier = (ign, column) =>
            {
                column.AllowDBNull = node.Nullable;
            };
            return applier;
        }

        protected override object InternalVisit(UniqueConstraintDefinition node)
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
                        .Select(c => table.Columns[Visit<string[]>(c.Column.MultiPartIdentifier).Last()])
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

                if (isPK)
                {
                    if (table.PrimaryKey.Length > 0)
                    {
                        var msg = string.Format("Cannot add multiple PRIMARY KEY constraints to table '{0}'", table.TableName);
                        throw new ArgumentException(msg);
                    }
                    else
                    {
                        table.PrimaryKey = columns;
                        table.Constraints.OfType<UniqueConstraint>()
                            .First(c => c.Columns.SequenceEqual(columns))
                            .ConstraintName = name;
                    }
                }
                else
                {
                    var existing = table.Constraints.OfType<UniqueConstraint>()
                        .FirstOrDefault(c => c.Columns.SequenceEqual(columns));
                    if (existing != null)
                    {
                        existing.ConstraintName = name;
                    }
                    else
                    {
                        table.Constraints.Add(new UniqueConstraint(name, columns, isPK));
                    }
                }
            };
            return applier;
        }

        protected override object InternalVisit(ForeignKeyConstraintDefinition node)
        {
            Action<DataTable, DataColumn> applier = (table, ignored) =>
            {
                var constraintName = node.ConstraintIdentifier.Value;

                DataTable refTable;
                {
                    var refTableName = Visit<string>(node.ReferenceTableName);
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
                fk.DeleteRule = GetDeleteUpdateRule(node.DeleteAction);
                fk.UpdateRule = GetDeleteUpdateRule(node.UpdateAction);
                if ((fk.DeleteRule == Rule.SetNull || fk.UpdateRule == Rule.SetNull)
                    && childs.Any(c => !c.AllowDBNull))
                {
                    var msg = string.Format("Cannot create the foreign key \"{0}\" with the SET NULL referential action, " +
                                            "because one or more referencing columns are not nullable.", constraintName);
                    throw new InvalidConstraintException(msg);
                }
                else if ((fk.DeleteRule == Rule.SetDefault || fk.UpdateRule == Rule.SetDefault)
                    && childs.Any(c => !c.AllowDBNull && c.DefaultValue == DBNull.Value))
                {
                    var msg = string.Format("Cannot create the foreign key \"{0}\" with the SET DEFAULT referential action, " +
                                            "because one or more referencing not-nullable columns lack a default constraint.", constraintName);
                    throw new InvalidConstraintException(msg);
                }
                table.Constraints.Add(fk);
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
