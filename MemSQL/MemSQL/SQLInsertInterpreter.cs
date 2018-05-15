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
            string[] columns = node.Columns.Select(s => pop<string>()).Reverse().ToArray();
            push(columns);
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
        public override void ExplicitVisit(ColumnReferenceExpression node)
        {
            node.AcceptChildren(this);
            Visit(node);
        }
        public override void Visit(ColumnReferenceExpression node)
        {
            //TODO:what if the column is not regular?
            //base.Visit(node);
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
            string[] keys = pop<string[]>();
            object[] values = pop<object[]>();
            DataTable table = pop<DataTable>();
            DataRow dr = table.NewRow();
            //what to do if they specified the names??
            Dictionary<string, object> namedValues = new Dictionary<string, object>();
            foreach (DataColumn column in table.Columns)
            {
                int index = Array.IndexOf(keys, column.ColumnName);
                if (index!=-1)
                {//i have value for this
                    namedValues.Add(keys[index], values[index]);
                }
                else {
                    //no value was provided for this
                    if (column.DefaultValue != null)
                    {
                        //i have default value for this column
                        namedValues.Add(column.ColumnName, column.DefaultValue);
                    }
                }

            }

            dr.ItemArray = namedValues.Values.ToArray();
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
