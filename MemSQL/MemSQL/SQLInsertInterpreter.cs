using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace MemSQL
{
    internal class SQLInsertInterpreter : SQLBaseInterpreter
    {
        public SQLInsertInterpreter(DataSet ds) : base(ds) { }

        protected override object InternalVisit(InsertStatement node)
        {
            return Visit<DataRow[]>(node.InsertSpecification);
        }

        protected override object InternalVisit(InsertSpecification node)
        {
            var table = Visit<DataTable>(node.Target);
            var rows = Visit<object[][]>(node.InsertSource);
            return rows.Select(row =>
            {
                DataRow dr = table.NewRow();
                //what to do if they specified the names??
                dr.ItemArray = row;
                table.Rows.Add(dr);
                return dr;
            }).ToArray();
        }

        protected override object InternalVisit(ValuesInsertSource node)
        {
            return node.RowValues.Select(rv => Visit<object[]>(rv)).ToArray();
        }

        protected override object InternalVisit(RowValue node)
        {
            //by now i should have all the values pushed into the stack, and the table right after.
            /*
            Stack<object> values = new Stack<object>();
            for (int i = 0; i < node.ColumnValues.Count; i++)
            {
                values.Push(pop<object>());
            }

            push(values.ToArray());
            */
            return node.ColumnValues.Select(cv => Visit<object>(cv)).ToArray();
        }

    }
}
