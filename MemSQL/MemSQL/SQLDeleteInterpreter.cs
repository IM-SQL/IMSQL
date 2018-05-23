using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace MemSQL
{
    internal class SQLDeleteInterpreter : SQLBaseInterpreter
    {
        public SQLDeleteInterpreter(DataSet ds) : base(ds) {}

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

            int size = table.Rows.Count;
            //TODO: if the table is infinite this will freeze everything. it should be lazy, maybe
            int top = size;
            if (node.TopRowFilter != null)
            {
                var t = Visit<TopResult>(node.TopRowFilter);
                double amount = t.Amount;
                if (t.Percent)
                {
                    amount = amount * size / 100;
                    amount = Math.Round(amount);
                }
                top = (int)amount;
            }
            //TODO:This environment should be kind of global
            Environment env = new Environment();

            Func<DataRow, bool> predicate = null;
            if (node.WhereClause == null)
            {
                predicate = new Func<DataRow, bool>((row) => true);
            }
            else {
                predicate = Visit<Func<Environment, Func<DataRow, bool>>>(node.WhereClause)(env);
            }
         
            List<DataRow> result = new List<DataRow>();
            int index = 0;
            while (index < size && result.Count < top)
            {
                int i = index++;
                var row = table.Rows[i];
                if (predicate(row)) { result.Add(row); }
            }
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