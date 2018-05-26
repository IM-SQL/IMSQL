using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace MemSQL
{
    internal class SQLDeleteInterpreter : SQLBaseInterpreter
    {
        public SQLDeleteInterpreter(Database db) : base(db) { }

        protected override object InternalVisit(DeleteStatement node)
        {
            return Visit<DataRow[]>(node.DeleteSpecification);
        }

        protected override object InternalVisit(DeleteSpecification node)
        {
            //TODO:node.FromClause;
            //TODO:node.OutputClause;
            //TODO:node.OutputIntoClause; 

            var env = Database.GlobalEnvironment.NewChild();

            var table = Visit<Tuple<string, DataTable>>(node.Target).Item2;
            var top = EvaluateExpression<TopResult>(node.TopRowFilter, env);
            var predicate = EvaluateExpression<Func<DataRow, bool>>(node.WhereClause, env, row => true);

            var result = Filter.From(table.Rows, predicate, top).ToArray();
            foreach (DataRow item in result)
            {
                // TODO(Richo): What happens if one of these throws an error?
                item.Delete();
            }
            table.AcceptChanges();
            return result;
        }
    }
}