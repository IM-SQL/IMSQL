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
            //TODO:node.WhereClause;

            var table = Visit<DataTable>(node.Target);

            int size = table.Rows.Count;

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


            Func<DataRow, bool> predicate;
            if (node.WhereClause != null)
            {
                predicate = Visit<Func<DataRow, bool>>(node.WhereClause);
            }
            else
            {
                predicate = (v) => { return true; };
            }

            List<DataRow> result = new List<DataRow>();
            int index = 0;

            while (index < size && result.Count < top)
            {
                int i = index++;
                if (predicate(table.Rows[i]))
                    result.Add(table.Rows[i]);
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