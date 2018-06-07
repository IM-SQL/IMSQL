using MemSQL.DataModel.Results;
using MemSQL.Result;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public abstract class SQLBaseInterpreter : SQLVisitor
    {
        public SQLBaseInterpreter(Database db)
        {
            Database = db;
        }

        protected Database Database { get; }

        protected IEnumerable<Func<Environment, T>> VisitExpressions<T>(IEnumerable<TSqlFragment> nodes)
        {
            return nodes.Select(VisitExpression<T>).ToArray();
        }

        protected internal Func<Environment, T> VisitExpression<T>(TSqlFragment node)
        {
            var func = Visit<Func<Environment, object>>(node);
            if (func == null) return null;
            return new Func<Environment, T>(env => (T)func(env));
        }

        protected internal T EvaluateExpression<T>(TSqlFragment node, Environment env, T defaultValue = default(T))
        {
            var func = VisitExpression<T>(node);
            if (func == null) return defaultValue;
            return func(env);
        }

        protected override object InternalVisit(MultiPartIdentifier node)
        {
            return node.Identifiers.Select(each => each.Value).ToArray();
        }

        protected override object InternalVisit(ColumnReferenceExpression node)
        {
            //TODO: this and SchemaObject should work differently.
            return Visit<string[]>(node.MultiPartIdentifier).Last();
        }

        protected override object InternalVisit(SchemaObjectName node)
        {
            //TODO:server, schema, and database identifier may take an important role here.
            return node.Identifiers.Last().Value;
        }

        protected override object InternalVisit(SqlDataTypeReference node)
        {
            /*
             * INFO(Richo): Based on the following table
             * https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-data-type-mappings
             */
            switch (node.SqlDataTypeOption)
            {
                case SqlDataTypeOption.Int:
                    return typeof(Int32);

                case SqlDataTypeOption.BigInt:
                    return typeof(Int64);

                case SqlDataTypeOption.SmallInt:
                    return typeof(Int16);

                case SqlDataTypeOption.TinyInt:
                    return typeof(Byte);

                case SqlDataTypeOption.Decimal:
                case SqlDataTypeOption.Numeric:
                case SqlDataTypeOption.Money:
                case SqlDataTypeOption.SmallMoney:
                    return typeof(Decimal);

                case SqlDataTypeOption.Text:
                case SqlDataTypeOption.NChar:
                case SqlDataTypeOption.NVarChar:
                case SqlDataTypeOption.NText:
                case SqlDataTypeOption.VarChar:
                case SqlDataTypeOption.Char:
                    //TODO: size limit? unicode limit?
                    //TODO: if this has more than 1 space, it should be a string
                    return typeof(String);

                case SqlDataTypeOption.Bit:
                    return typeof(Boolean);

                case SqlDataTypeOption.Float:
                    return typeof(Double);

                case SqlDataTypeOption.Real:
                    return typeof(Single);

                case SqlDataTypeOption.Date:
                case SqlDataTypeOption.DateTime:
                case SqlDataTypeOption.DateTime2:
                case SqlDataTypeOption.SmallDateTime:
                    return typeof(DateTime);

                case SqlDataTypeOption.Time:
                    return typeof(TimeSpan);

                case SqlDataTypeOption.DateTimeOffset:
                    return typeof(DateTimeOffset);

                case SqlDataTypeOption.Binary:
                case SqlDataTypeOption.VarBinary:
                case SqlDataTypeOption.Image:
                case SqlDataTypeOption.Rowversion:
                case SqlDataTypeOption.Timestamp:
                    return typeof(Byte[]);

                case SqlDataTypeOption.Sql_Variant:
                    return typeof(Object);

                case SqlDataTypeOption.UniqueIdentifier:
                    return typeof(Guid);

                case SqlDataTypeOption.None:
                case SqlDataTypeOption.Cursor:
                case SqlDataTypeOption.Table:
                default:
                    throw new NotSupportedException();
            }
        }

        protected override object InternalVisit(IntegerLiteral node)
        {
            return new Func<Environment, object>(env => int.Parse(node.Value));
        }

        protected override object InternalVisit(StringLiteral node)
        {
            return new Func<Environment, object>(env => node.Value.ToString());
        }

        protected override object InternalVisit(NullLiteral node)
        {
            return new Func<Environment, object>(env => null);
        }

        protected override object InternalVisit(NamedTableReference node)
        {
            var tableName = Visit<string>(node.SchemaObject);

            //TODO: this is actually a kind of hack, if i am in presence of an
            var realTable = Database.GetTable(tableName);
            if (node.Alias != null) {
                return new RecordSet(node.Alias.Value, realTable.Columns, realTable.Rows);
            }
            //TODO: make this a result?.
            //If i make this a result, the insert, delete, or update wont work. they need the real table here.
            return realTable;
        }

        protected override object InternalVisit(TopRowFilter node)
        {
            return new Func<Environment, object>(env =>
            {
                return new TopResult(
                    amount: EvaluateExpression<int>(node.Expression, env),
                    percent: node.Percent,
                    ties: node.WithTies);
            });
        }

        /*INFO(Tera):i believe the expressions should be habdled differently,
         * and should always start a new interpreter from the top of the expression*/
        protected override object InternalVisit(ParenthesisExpression node)
        {
            return new SQLExpressionInterpreter(Database).InternalVisit(node);
        }

        protected override object InternalVisit(WhereClause node)
        {
            //TODO: node.Cursor
            return new SQLExpressionInterpreter(Database).Visit<object>(node);
        }

        protected override object InternalVisit(BooleanBinaryExpression node)
        {
            //TODO: node.Cursor
            return new SQLExpressionInterpreter(Database).Visit<object>(node);
        }

        protected override object InternalVisit(BooleanNotExpression node)
        {
            //TODO: node.Cursor
            return new SQLExpressionInterpreter(Database).Visit<object>(node);
        }

        protected override object InternalVisit(SearchedCaseExpression node)
        {
            //TODO: node.Cursor
            return new SQLExpressionInterpreter(Database).Visit<object>(node);
        }



        //TODO: maybe move this to a subclass
        protected virtual RecordSet ApplyOutputClause(RecordSet source, OutputClause clause)
        {
            var selectors = Visit<Func<Environment, Func<RecordTable, (string, Func<Record, object>)[]>>>(clause)?.Invoke(Database.GlobalEnvironment)(source);
            if (selectors != null)
            {
                return new RecordSet(source.TableName,selectors, Filter.From(source.Records, (row) => true, null));
            }
            return null;
        }
        protected override object InternalVisit(OutputClause node)
        {
            return new Func<Environment, Func<RecordTable, (string, Func<Record, object>)[]>>(
                (env) =>
                {
                    return new Func<RecordTable, (string, Func<Record, object>)[]>((table) =>
                    {
                        return node.SelectColumns.SelectMany(
                            (element) =>
                            {
                                return EvaluateExpression<Func<RecordTable, (string, Func<Record, object>)[]>>(element, env)(table);
                            }).ToArray();
                    });

                });
        }

        protected override object InternalVisit(SelectStarExpression node)
        {
            return new Func<Environment, object>(env =>
            {
                return new Func<RecordTable, (string, Func<Record, object>)[]>(table =>
                {
                    return table.Columns.Select(col => col.GetDefaultSelector).ToArray();
                });
            });
        }

        protected override object InternalVisit(SelectScalarExpression node)
        {
            return new Func<Environment, object>(env =>
            {
                return new Func<RecordTable, (string, Func<Record, object>)[]>(table =>
                {
                    SQLExpressionInterpreter expressionInterpreter = new SQLExpressionInterpreter(Database);
                    var expr = expressionInterpreter.Visit<Func<Environment, object>>(node.Expression);
                    var innerEnv = env.NewChild();
                    var selector = new Func<Record, object>((row) =>
                    {
                        innerEnv.Add("currentRow", row);
                        return expr(innerEnv);
                    });
                    //what about node.ColumnName.Identifier ??
                    string name = null;
                    if (node.ColumnName != null)
                    {
                        name = node.ColumnName.Value;
                    }
                    else
                    {
                        //try to get the column name from the selected expression, if possible.
                        //TODO: if i do a select (3+4) sql server says something like "(no column name)", i am guessing a result column should have a nullable name
                        name = node.ScriptTokenStream[node.LastTokenIndex].Text;
                    }
                    return new(string, Func<Record, object>)[] { (name, selector) };
                });
            });
        }
    }
}
