﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSQL.DataModel;
using IMSQL.DataModel.Results;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace IMSQL
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
            return new Func<Environment, Func<IResultRow, bool>>((env) =>
            {
                var filter = VisitExpression<bool>(node.SearchCondition);
                var subEnv = env.NewChild();
                return new Func<IResultRow, bool>((row) =>
                {
                    subEnv.CurrentRow = row;
                    return filter(subEnv);
                });
            });
        }

        protected override object InternalVisit(BooleanComparisonExpression node)
        {
            var comparer = SQLComparer.Default;
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
            return new Func<Environment, object>((env) =>
            {
                return env.CurrentRow[Visit<string[]>(node.MultiPartIdentifier)];
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

        protected override object InternalVisit(SearchedCaseExpression node)
        {
            //TODO:node.Collation
            Func<Environment, object> def = Visit<Func<Environment, object>>(node.ElseExpression);
            //the key should be a predicate.
            Dictionary<Func<Environment, object>, Func<Environment, object>> clauses = new Dictionary<Func<Environment, object>, Func<Environment, object>>();
            foreach (var clause in node.WhenClauses)
            {
                clauses.Add(
                    Visit<Func<Environment, object>>(clause.WhenExpression),
                    Visit<Func<Environment, object>>(clause.ThenExpression)
                    );
            }
            return new Func<Environment, object>((env) =>
            {
                foreach (var c in clauses)
                {
                    if ((bool)c.Key(env))
                    { return c.Value(env); }
                }
                return def(env);
            });
        }

        protected override object InternalVisit(BinaryExpression node)
        {
            //TODO: type checking?
            Func<Environment, object> result;
            switch (node.BinaryExpressionType)
            {
                case BinaryExpressionType.Add:
                    result = new Func<Environment, object>((env) =>
                    {
                        var first = EvaluateExpression<dynamic>(node.FirstExpression, env);
                        var second = EvaluateExpression<dynamic>(node.SecondExpression, env);
                        return first + second;
                    });
                    break;
                case BinaryExpressionType.Subtract:
                    result = new Func<Environment, object>((env) =>
                    {
                        var first = EvaluateExpression<dynamic>(node.FirstExpression, env);
                        var second = EvaluateExpression<dynamic>(node.SecondExpression, env);
                        return first - second;
                    });
                    break;
                case BinaryExpressionType.Multiply:
                    result = new Func<Environment, object>((env) =>
                    {
                        var first = EvaluateExpression<dynamic>(node.FirstExpression, env);
                        var second = EvaluateExpression<dynamic>(node.SecondExpression, env);
                        return first * second;
                    });
                    break;
                case BinaryExpressionType.Divide:
                    result = new Func<Environment, object>((env) =>
                    {
                        var first = EvaluateExpression<dynamic>(node.FirstExpression, env);
                        var second = EvaluateExpression<dynamic>(node.SecondExpression, env);
                        return first / second;
                    });
                    break;
                case BinaryExpressionType.Modulo:
                    result = new Func<Environment, object>((env) =>
                    {
                        var first = EvaluateExpression<dynamic>(node.FirstExpression, env);
                        var second = EvaluateExpression<dynamic>(node.SecondExpression, env);
                        return first % second;
                    });
                    break;
                case BinaryExpressionType.BitwiseAnd:
                    result = new Func<Environment, object>((env) =>
                    {
                        var first = EvaluateExpression<dynamic>(node.FirstExpression, env);
                        var second = EvaluateExpression<dynamic>(node.SecondExpression, env);
                        return first & second;
                    });
                    break;
                case BinaryExpressionType.BitwiseOr:
                    result = new Func<Environment, object>((env) =>
                    {
                        var first = EvaluateExpression<dynamic>(node.FirstExpression, env);
                        var second = EvaluateExpression<dynamic>(node.SecondExpression, env);
                        return first | second;
                    });
                    break;
                case BinaryExpressionType.BitwiseXor:
                    result = new Func<Environment, object>((env) =>
                    {
                        var first = EvaluateExpression<dynamic>(node.FirstExpression, env);
                        var second = EvaluateExpression<dynamic>(node.SecondExpression, env);
                        return first ^ second;
                    });
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }
        protected override object InternalVisit(FunctionCall node)
        {
            //TODO: node.CallTarget
            //TODO: node.Collation
            //TODO: node.OverClause
            //TODO: node.Parameters
            //TODO: node.UniqueRowFilter
            //TODO: node.WithinGroupClause 

            //I think that this should return a function that returns a function,
            //binding the call execution to the creation context? 
           var parameters= node.Parameters.Select(p => Visit<Func<Environment, object>>(p));
            var specification = new CallSpecification(node,parameters);
            return new Func<Environment, object>((env) => {
                return env.GetFunction(node.FunctionName.Value.ToUpper())(specification,env);
            });
        }
    }
}
