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
        public SQLExpressionInterpreter(Database db) : base(db) { }

        protected override object InternalVisit(ParenthesisExpression node)
        {
            return Visit<object>(node.Expression);
        }

        protected override object InternalVisit(WhereClause node)
        {
            //TODO: node.Cursor
            return new Func<Environment, Func<DataRow, bool>>((env) =>
            {
                var filter = VisitExpression<bool>(node.SearchCondition);
                var subEnv = env.NewChild();
                return new Func<DataRow, bool>((row) =>
                {
                    subEnv.Add("currentRow", row);
                    return filter(subEnv);
                });
            });
        }

        protected override object InternalVisit(BooleanComparisonExpression node)
        {
            var comparer = Comparer.DefaultInvariant;
            Func<object, object, bool> func;

            switch (node.ComparisonType)
            {
                case BooleanComparisonType.Equals:
                    func = (first, second) => 0 == comparer.Compare(first, second);
                    break;

                case BooleanComparisonType.GreaterThan:
                    func = (first, second) => 1 == comparer.Compare(first, second);
                    break;

                case BooleanComparisonType.LessThan:
                    func = (first, second) => -1 == comparer.Compare(first, second);
                    break;

                case BooleanComparisonType.NotLessThan:
                case BooleanComparisonType.GreaterThanOrEqualTo:
                    func = (first, second) => -1 < comparer.Compare(first, second);
                    break;

                case BooleanComparisonType.NotGreaterThan:
                case BooleanComparisonType.LessThanOrEqualTo:
                    func = (first, second) => 1 > comparer.Compare(first, second);
                    break;

                case BooleanComparisonType.NotEqualToBrackets:
                case BooleanComparisonType.NotEqualToExclamation:
                    func = (first, second) => 0 != comparer.Compare(first, second);
                    break;

                case BooleanComparisonType.LeftOuterJoin:
                case BooleanComparisonType.RightOuterJoin:
                default:
                    throw new NotImplementedException();
            }

            return new Func<Environment, object>((env) =>
            {
                var first = EvaluateExpression<object>(node.FirstExpression, env);
                var second = EvaluateExpression<object>(node.SecondExpression, env);
                return func(first, second);
            });
        }

        protected override object InternalVisit(ColumnReferenceExpression node)
        {
            //TODO(Tera): we should check what about the other parts of the identifier
            return new Func<Environment, object>((env) =>
            {
                return env.At<DataRow>("currentRow")[Visit<string[]>(node.MultiPartIdentifier).Last()];
            });
        }

        protected override object InternalVisit(BooleanBinaryExpression node)
        {
            Func<bool, bool, bool> func = null;
            switch (node.BinaryExpressionType)
            {
                case BooleanBinaryExpressionType.And:
                    func = (first, second) => first && second;
                    break;

                case BooleanBinaryExpressionType.Or:
                    func = (first, second) => first || second;
                    break;
            }
            return new Func<Environment, object>(env =>
            {
                // INFO(Richo): We don't need to implement short-circuit because it's not a requirement for SQL
                bool first = EvaluateExpression<bool>(node.FirstExpression, env);
                bool second = EvaluateExpression<bool>(node.SecondExpression, env);
                return func(first, second);
            });
        }

        protected override object InternalVisit(BooleanNotExpression node)
        {
            return new Func<Environment, object>(env =>
            {
                return !EvaluateExpression<bool>(node.Expression, env);
            });
        }
    }
}
