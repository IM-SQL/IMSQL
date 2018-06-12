using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IMSQL.DataModel.Results;
using IMSQL.Result;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace IMSQL
{
    internal class SQLDeleteInterpreter : SQLBaseInterpreter
    {
        public SQLDeleteInterpreter(Database db) : base(db) { }

        protected override object InternalVisit(DeleteStatement node)
        {
            return Visit<SQLExecutionResult>(node.DeleteSpecification);
        }

        protected override object InternalVisit(DeleteSpecification node)
        {
            //TODO:node.FromClause;
            //TODO:node.OutputIntoClause; 

            var env = Database.GlobalEnvironment.NewChild();

            var table = (Table)Visit<IResultTable>(node.Target);
            var top = EvaluateExpression<TopResult>(node.TopRowFilter, env);
            var predicate = EvaluateExpression<Func<Row, bool>>(node.WhereClause, env, row => true);

            var rows = Filter.From(table.Rows, predicate, top).ToArray();
            foreach (Row item in rows)
            {
                // TODO(Richo): What happens if one of these throws an error?
                item.Delete();
            }
            table.AcceptChanges();
            return new SQLExecutionResult(rows.Count(),
                ApplyOutputClause(new RecordTable("DELETED",table.Columns, rows), node.OutputClause));
        }
    }
}