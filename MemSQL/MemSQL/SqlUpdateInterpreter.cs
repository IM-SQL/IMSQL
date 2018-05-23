using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace MemSQL
{
    internal class SQLUpdateInterpreter : SQLBaseInterpreter
    {
        public SQLUpdateInterpreter(DataSet ds) : base(ds) { }


        protected override object InternalVisit(UpdateStatement node)
        {
            //TODO:node.OptimizerHints
            //TODO:node.WithCtesAndXmlNamespaces

            return Visit<DataRow[]>(node.UpdateSpecification);
        }

        protected override object InternalVisit(UpdateSpecification node)
        {
            //TODO:node.FromClause
            //TODO:node.OutputClause
            //TODO:node.OutputIntoClause 

            var table = Visit<DataTable>(node.Target);

            int size = table.Rows.Count;
            //TODO: if the table is infinite this will freeze everything. it should be lazy, maybe
            //TODO: i think that the With Ties hint has an effect on the update that we are not reproducing correctly
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
            else
            {
                predicate = Visit<Func<Environment, Func<DataRow, bool>>>(node.WhereClause)(env);
            }

            Action<DataRow> setClause = CreateSetClause(node.SetClauses, env);

            List<DataRow> result = new List<DataRow>();
            int index = 0;
            while (index < size && result.Count < top)
            {
                int i = index++;
                var row = table.Rows[i];
                if (predicate(row))
                {
                    setClause(row);
                    result.Add(row);
                }
            }
            table.AcceptChanges();
            return result.ToArray();
        }
        private Action<DataRow> CreateSetClause(IList<SetClause> clauses, Environment env)
        {
            var sets = Visit<Func<Environment, Action<DataRow>>>(clauses).Select(f => f(env));
            return new Action<DataRow>((row) =>
            {
                foreach (var item in sets)
                {
                    item(row);
                }
            });
        }
        //TODO: this may be useful in the parent class.
        public IEnumerable<T> Visit<T>(IEnumerable<TSqlFragment> nodes, T defaultValue = default(T))
        {
            return nodes.Select(n => Visit<T>(n, defaultValue));
        }


        protected override object InternalVisit(AssignmentSetClause node)
        {
            //TODO: node.AssignmentKind

            return new Func<Environment, Action<DataRow>>((env) =>
            {

                string columnName = Visit<string>(node.Column);

                return new Action<DataRow>((row) =>
                {
                    object value = Visit<Func<Environment, object>>(node.NewValue)(env);
                    row[columnName] = value;
                });
            });
        }
    }
}