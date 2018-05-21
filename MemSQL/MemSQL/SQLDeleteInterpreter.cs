using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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


            Func<Environment, IEnumerable<DataRow>> filter;
            if (node.WhereClause != null)
            {
                filter = Visit<Func<Environment, IEnumerable<DataRow>>>(node.WhereClause);
            }
            else
            {
                //TODO: this code is duplicated, perhaps i should just create a where 1=1?
                filter = (v) =>
                {
                    DataTable _table = v.At<DataTable>("Target");
                    int _top = v.At<int>("Top");
                    int _size = table.Rows.Count;

                    int index = 0;
                    List<DataRow> r = new List<DataRow>();
                    while (index < _size && r.Count < _top)
                    {
                        int i = index++;
                         r.Add(_table.Rows[i]);
                    }
                    return r;

                };
            }

            List<DataRow> result = new List<DataRow>();
            Environment env = new Environment();
            env.Add("Top", top);
            env.Add("Target", table);
            result.AddRange(filter(env.NewChild()));

            foreach (DataRow item in result)
            {
                item.Delete();
            }
            table.AcceptChanges();
            return result.ToArray();
        }
    }
}