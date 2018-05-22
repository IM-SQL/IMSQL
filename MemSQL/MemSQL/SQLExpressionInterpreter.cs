using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace MemSQL
{
    internal class SQLExpressionInterpreter : SQLBaseInterpreter
    {
        Environment currentEnvironment;

        public SQLExpressionInterpreter(DataSet ds) : base(ds) {}

        protected override object InternalVisit(ParenthesisExpression node)
        {
            return Visit<object>(node.Expression);
        }

        protected override object InternalVisit(WhereClause node)
        {
            //TODO: node.Cursor
            return new Func<Environment, IEnumerable<DataRow>>((env) =>
            {
                DataTable table = env.At<DataTable>("Target");
                int top = env.At<int>("Top");
                int size = table.Rows.Count;
                int index = 0;

                currentEnvironment = env;
                env.Add("currentRow", null);
                var filter = Visit<Func<bool>>(node.SearchCondition);
                List<DataRow> result = new List<DataRow>();
                while (index < size && result.Count < top)
                {
                    int i = index++;
                    env["currentRow"] = table.Rows[i];
                    if (filter())
                        result.Add(table.Rows[i]);
                }
                return result;
            });
        }

        protected override object InternalVisit(BooleanComparisonExpression node)
        {
            int target = 0;

            switch (node.ComparisonType)
            {
                case BooleanComparisonType.Equals:
                    target = 0;
                    break;
                case BooleanComparisonType.GreaterThan:
                    target = 1;
                    break;
                case BooleanComparisonType.LessThan:
                    target = -1;
                    break;
                case BooleanComparisonType.NotLessThan:
                case BooleanComparisonType.GreaterThanOrEqualTo:
                    return new Func<bool>(() =>
                    {
                        var first = Visit<Func<object>>(node.FirstExpression)();
                        var second = Visit<Func<object>>(node.SecondExpression)();
                        return -1 < Comparer.DefaultInvariant.Compare(first, second);
                    });
                case BooleanComparisonType.NotGreaterThan:
                case BooleanComparisonType.LessThanOrEqualTo:
                    return new Func<bool>(() =>
                    {
                        var first = Visit<Func<object>>(node.FirstExpression)();
                        var second = Visit<Func<object>>(node.SecondExpression)();
                        return 1 > Comparer.DefaultInvariant.Compare(first, second);
                    });


                case BooleanComparisonType.NotEqualToBrackets:
                case BooleanComparisonType.NotEqualToExclamation:
                    return new Func<bool>(() =>
                    {
                        var first = Visit<Func<object>>(node.FirstExpression)();
                        var second = Visit<Func<object>>(node.SecondExpression)();
                        return 0 != Comparer.DefaultInvariant.Compare(first, second);
                    });

                case BooleanComparisonType.LeftOuterJoin:
                case BooleanComparisonType.RightOuterJoin:
                default:
                    throw new NotImplementedException();
            }
            return new Func<bool>(() =>
            {
                var first = Visit<Func<object>>(node.FirstExpression)();
                var second = Visit<Func<object>>(node.SecondExpression)();
                return target == Comparer.DefaultInvariant.Compare(first, second);
            });
        }

        protected override object InternalVisit(ColumnReferenceExpression node)
        {
            //TODO(Tera): we should check what about the other parts of the identifier
            return new Func<object>(() =>
            {
                return currentEnvironment.At<DataRow>("currentRow")[Visit<string[]>(node.MultiPartIdentifier).Last()];
            });
        }

        protected override object InternalVisit(BooleanBinaryExpression node)
        {
            switch (node.BinaryExpressionType)
            {
                case BooleanBinaryExpressionType.And:
                    return new Func<bool>(() =>
                    {
                        // TODO(Richo): Should we implement short circuit? Check SQL server...
                        var first = Visit<Func<bool>>(node.FirstExpression)();
                        var second = Visit<Func<bool>>(node.SecondExpression)();
                        return first && second;
                    });
                case BooleanBinaryExpressionType.Or:
                    return new Func<bool>(() =>
                    {
                        // TODO(Richo): Should we implement short circuit? Check SQL server...
                        var first = Visit<Func<bool>>(node.FirstExpression)();
                        var second = Visit<Func<bool>>(node.SecondExpression)();
                        return first || second;
                    });
                default:
                    throw new NotImplementedException();
            }
        }

        protected override object InternalVisit(BooleanNotExpression node)
        {
            return new Func<bool>(() => { return !(Visit<Func<bool>>(node.Expression)()); });
        }
    }
}
