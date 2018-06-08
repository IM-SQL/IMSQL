using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MemSQL.DataModel.Results;
using MemSQL.Result;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace MemSQL
{
    internal class SQLUpdateInterpreter : SQLBaseInterpreter
    {
        public SQLUpdateInterpreter(Database db) : base(db) { }

        protected override object InternalVisit(UpdateStatement node)
        {
            //TODO:node.OptimizerHints
            //TODO:node.WithCtesAndXmlNamespaces

            return Visit<SQLExecutionResult>(node.UpdateSpecification);
        }

        protected override object InternalVisit(UpdateSpecification node)
        {
            //TODO:node.FromClause
            //TODO:node.OutputIntoClause 

            var env = Database.GlobalEnvironment.NewChild();

            var table = (Table)Visit<IResultTable>(node.Target);
            var top = EvaluateExpression<TopResult>(node.TopRowFilter, env);
            var predicate = EvaluateExpression<Func<Row, bool>>(node.WhereClause, env, row => true);

            Action<Row> setClause = CreateSetClause(node.SetClauses, env);

            List<Row> rows = new List<Row>();
            rows.AddRange(Filter.From(table.Rows, predicate, top));
            foreach (var item in rows)
            {
                setClause(item);
            }
            table.AcceptChanges();

            return new SQLExecutionResult(rows.Count(),
                ApplyOutputClause(new RecordTable("UPDATED",table.Columns, rows), node.OutputClause));

        }

        private Action<Row> CreateSetClause(IList<SetClause> clauses, Environment env)
        {
            var sets = VisitExpressions<Action<Row>>(clauses)
                .Select(f => f(env))
                .ToArray();

            return new Action<Row>(row =>
            {
                foreach (var item in sets)
                {
                    item(row);
                }
            });
        }

        protected override object InternalVisit(AssignmentSetClause node)
        {
            Func<dynamic, dynamic, object> operation = null;
            switch (node.AssignmentKind)
            {
                case AssignmentKind.Equals:
                    operation = new Func<dynamic, dynamic, object>((a, b) => b);
                    break;
                case AssignmentKind.AddEquals:
                    operation = new Func<dynamic, dynamic, object>((a, b) => a + b);
                    break;
                case AssignmentKind.SubtractEquals:
                    operation = new Func<dynamic, dynamic, object>((a, b) => a - b);
                    break;
                case AssignmentKind.MultiplyEquals:
                    operation = new Func<dynamic, dynamic, object>((a, b) => a * b);
                    break;
                case AssignmentKind.DivideEquals:
                    operation = new Func<dynamic, dynamic, object>((a, b) => a / b);
                    break;
                case AssignmentKind.ModEquals:
                    operation = new Func<dynamic, dynamic, object>((a, b) => a % b);
                    break;
                //TODO: bitwise operations may not be equivalent to the Sql ones. We should check this out later.
                case AssignmentKind.BitwiseAndEquals:
                    operation = new Func<dynamic, dynamic, object>((a, b) => a & b);
                    break;
                case AssignmentKind.BitwiseOrEquals:
                    operation = new Func<dynamic, dynamic, object>((a, b) => a | b);
                    break;
                case AssignmentKind.BitwiseXorEquals:
                    operation = new Func<dynamic, dynamic, object>((a, b) => a ^ b);
                    break;
                default:
                    //just in case they add something here in the future
                    throw new NotImplementedException();
            }

            return new Func<Environment, Action<Row>>((env) =>
            {
                string columnName = Visit<string>(node.Column);
                return new Action<Row>((row) =>
                {
                    object providedValue = EvaluateExpression<object>(node.NewValue, env);
                    row[columnName] = operation(row[columnName], providedValue);
                });
            });
        }

    }
}