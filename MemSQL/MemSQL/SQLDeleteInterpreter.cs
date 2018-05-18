using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace MemSQL
{
    internal class SQLDeleteInterpreter : SQLBaseInterpreter
    {
        public SQLDeleteInterpreter(DataSet ds) : base(ds)
        {
        }

        protected override object InternalVisit(DeleteStatement node)
        {
            return Visit<DataRow[]>(node.DeleteSpecification);

        }
        protected override object InternalVisit(DeleteSpecification node)
        {
            //TODO:node.FromClause;
            //TODO:node.OutputClause;
            //TODO:node.OutputIntoClause;
            //TODO:node.Target;
            //TODO:node.TopRowFilter;
            //TODO:node.WhereClause;

            var table = Visit<DataTable>(node.Target);
            List<DataRow> result = new List<DataRow>();
            foreach (DataRow item in table.Rows)
            {
                result.Add(item);
            }
            foreach (DataRow item in result)
            {
                item.Delete();
            }
            table.AcceptChanges();
            return result.ToArray();
        }
    }
}