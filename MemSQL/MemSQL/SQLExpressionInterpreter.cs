using System;
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
        public SQLExpressionInterpreter(DataSet ds) : base(ds)
        {
        }
        protected override object InternalVisit(ParenthesisExpression node)
        {
            return Visit<object>(node.Expression);
        }

        DataRow currentRow;
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
                    return new Func<DataRow, bool>((row) =>
                    {
                        currentRow = row;
                        var first = Visit<Func<object>>(node.FirstExpression)();
                        var second = Visit<Func<object>>(node.SecondExpression)();
                        return -1 < System.Collections.Comparer.DefaultInvariant.Compare(first, second);
                    });
                case BooleanComparisonType.NotGreaterThan:
                case BooleanComparisonType.LessThanOrEqualTo:
                    return new Func<DataRow, bool>((row) =>
                    {
                        currentRow = row;
                        var first = Visit<Func<object>>(node.FirstExpression)();
                        var second = Visit<Func<object>>(node.SecondExpression)();
                        return 1 > System.Collections.Comparer.DefaultInvariant.Compare(first, second);
                    });


                case BooleanComparisonType.NotEqualToBrackets:
                case BooleanComparisonType.NotEqualToExclamation:
                    return new Func<DataRow, bool>((row) =>
                    {
                        currentRow = row;
                        var first = Visit<Func<object>>(node.FirstExpression)();
                        var second = Visit<Func<object>>(node.SecondExpression)();
                        return 0 != System.Collections.Comparer.DefaultInvariant.Compare(first, second);
                    });

                case BooleanComparisonType.LeftOuterJoin:
                case BooleanComparisonType.RightOuterJoin:
                default:
                    throw new NotImplementedException();
            }
            return new Func<DataRow, bool>((row) =>
            {
                currentRow = row;
                var first = Visit<Func<object>>(node.FirstExpression)();
                var second = Visit<Func<object>>(node.SecondExpression)();
                return target == System.Collections.Comparer.DefaultInvariant.Compare(first, second);
            });

        }

        protected override object InternalVisit(ColumnReferenceExpression node)
        {
            //TODO(Tera): we should check what about the other parts of the identifier
            return new Func<object>(() =>
            {
                return currentRow[node.MultiPartIdentifier.Identifiers.Last().Value];
            });
        }
        protected override object InternalVisit(BooleanBinaryExpression node)
        {
            switch (node.BinaryExpressionType)
            {
                case BooleanBinaryExpressionType.And:
                    return new Func<bool>(() =>
                    {
                        var first = (bool)Visit<Func<object>>(node.FirstExpression)();
                        var second = (bool)Visit<Func<object>>(node.SecondExpression)();
                        return first && second;
                    }); 
                case BooleanBinaryExpressionType.Or:
                    return new Func<bool>(() =>
                    {
                        var first = (bool)Visit<Func<object>>(node.FirstExpression)();
                        var second = (bool)Visit<Func<object>>(node.SecondExpression)();
                        return first || second;
                    });
                default:
                    break;
            }
            ;
        }
        protected override object InternalVisit(BooleanNotExpression node)
        {
            return new Func<object>(() => { return !((bool)Visit<object>(node.Expression)); });
        }
    }
}
