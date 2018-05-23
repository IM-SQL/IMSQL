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

            var table = Visit<DataTable>(node.Target);
            TopResult top = Visit<TopResult>(node.TopRowFilter);

            //TODO:This environment should be kind of global
            Environment env = new Environment();

            Func<DataRow, bool> predicate = null;
            if (node.WhereClause == null)
            {
                predicate = new Func<DataRow, bool>((row) => true);
            }
            else
            {
                predicate = Visit<Func<Environment, Func<DataRow, bool>>>(node.WhereClause)(env);
            }

            List<DataRow> result = new List<DataRow>();

            result.AddRange(Filter.From(table.Rows.AsEnumerable(), predicate, top));
            foreach (DataRow item in result)
            {
                // TODO(Richo): What happens if one of these throws an error?
                item.Delete();
            }
            table.AcceptChanges();
            return result.ToArray();
        }
    }
}