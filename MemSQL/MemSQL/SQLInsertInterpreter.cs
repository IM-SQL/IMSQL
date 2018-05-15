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
            var providedColumns = node.Columns.Select(columnReference => Visit<string>(columnReference)).ToArray();
            var providedValue = Visit<object[][]>(node.InsertSource);

            //if no column was provided then the whole table has to be provided as parameter.
            if (providedColumns.Length == 0)
            {
                    providedColumns = new string[table.Columns.Count];
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    providedColumns[i] = table.Columns[i].ColumnName;
                }
            }

            List<object[]> rows = new List<object[]>(providedValue.Select(r => new object[table.Columns.Count]));
            for (int i = 0; i < table.Columns.Count; i++)
            {
                int index = Array.IndexOf(providedColumns, table.Columns[i].ColumnName);
                if (index != -1)
                {
                    //a value for this column was provided, and as such i should use the value.
                    for (int j = 0; j < providedValue.Length; j++)
                    {
                        rows[j][i] = providedValue[j][index];
                    }
                }
                else
                {
                    object value = table.Columns[i].DefaultValue;
                    //check if the column has a default value 
                    if (value != null)
                    {
                        for (int j = 0; j < providedValue.Length; j++)
                        {
                            rows[j][i] = value;
                        }
                    }
                    else
                    {
                        if (!table.Columns[i].AllowDBNull)
                        {
                            throw new InvalidOperationException(string.Format("A Null was provided for the column {0}", table.Columns[i].ColumnName));
                        }
                    }
                }

            }
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
            return node.ColumnValues.Select(cv => Visit<object>(cv)).ToArray();
        }

    }
}
