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
            var rows = Visit<object[][]>(node.InsertSource);

            //if no column was provided then the whole table has to be provided as parameter.
            if (providedColumns.Length == 0)
            {
                providedColumns = new string[table.Columns.Count];
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    providedColumns[i] = table.Columns[i].ColumnName;
                }
            }

            return rows.Select(row =>
          {
              DataRow dr = table.NewRow();
              //what to do if they specified the names??
              for (int i = 0; i < providedColumns.Length; i++)
              {
                  dr[providedColumns[i]] = row[i];
              }
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
