using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace MemSQL
{
    internal class SQLInsertInterpreter : SQLVisitor
    {
        public SQLInsertInterpreter(DataSet ds) : base(ds)
        {
        }

        public override void ExplicitVisit(InsertStatement node)
        {
            node.AcceptChildren(this);
            Visit(node);
        }
        public override void ExplicitVisit(InsertSpecification node)
        {
            node.AcceptChildren(this);
            Visit(node);
        }
        public override void ExplicitVisit(ValuesInsertSource node)
        {
            node.AcceptChildren(this);
            Visit(node);
        }
        public override void ExplicitVisit(RowValue node)
        {
            node.AcceptChildren(this);
            Visit(node);
        }

        public override void Visit(InsertStatement node)
        {
            DataRow dr = pop<DataRow>();
            DataTable table = pop<DataTable>();
            table.Rows.Add(dr);

            push(dr);
        }
        public override void Visit(InsertSpecification node)
        {
            object[] values = pop<object[]>();
            DataTable table = pop<DataTable>();
            DataRow dr = table.NewRow();
            //what to do if they specified the names??
            dr.ItemArray = values;
            push(table);
            push(dr);
        }
        public override void Visit(ValuesInsertSource node)
        {
           //do nothing for now, i think.
        }
        public override void Visit(RowValue node)
        {
            //by now i should have all the values pushed into the stack, and the table right after.

            Stack<object> values = new Stack<object>();
            for (int i = 0; i < node.ColumnValues.Count; i++)
            {
                values.Push(pop<object>());
            }

            push(values.ToArray());
        }

    }
}
