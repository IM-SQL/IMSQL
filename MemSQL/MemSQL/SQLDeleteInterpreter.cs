﻿using System;
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
            
            // TODO(Richo): Hack to make sure all rows are deleted when no WHERE is specified
            if (node.WhereClause == null)
            {
                node.WhereClause = new WhereClause()
                {
                    SearchCondition=new BooleanComparisonExpression()
                    {
                        ComparisonType = BooleanComparisonType.Equals,
                        FirstExpression = new StringLiteral() { Value="" },
                        SecondExpression = new StringLiteral() { Value="" }
                    }
                };
            }
            var filter = Visit<Func<Environment, IEnumerable<DataRow>>>(node.WhereClause);

            List<DataRow> result = new List<DataRow>();
            Environment env = new Environment();
            env.Add("Top", top);
            env.Add("Target", table);
            result.AddRange(filter(env.NewChild()));

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