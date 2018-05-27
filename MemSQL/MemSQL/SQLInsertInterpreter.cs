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
        public SQLInsertInterpreter(Database db) : base(db) { }

        protected override object InternalVisit(InsertStatement node)
        {
            return Visit<DataRow[]>(node.InsertSpecification);
        }

        protected override object InternalVisit(InsertSpecification node)
        {
            var table = Visit<Tuple<string, DataTable>>(node.Target).Item2;
            List<string> providedColumns = node.Columns
                .Select(columnReference => Visit<string>(columnReference))
                .ToList();
            var rows = Visit<object[][]>(node.InsertSource);

            //if no column was provided then the whole table has to be provided as parameter. 
            if (providedColumns.Count == 0)
            {
                providedColumns = new List<string>();
                for (int i = 0; i < table.Columns.Count(); i++)
                {
                    if (!table.GetColumn(i).AutoIncrement)
                    {
                        providedColumns.Add(table.GetColumn(i).ColumnName);
                    }
                }
            }
            else
            {
                if (providedColumns.Any(name => table.GetColumn(name).AutoIncrement))
                {
                    throw new InvalidOperationException("Cannot insert explicit value for identity column");
                }
            }

            if (providedColumns.Count != rows[0].Length)
            {
                //there are probably columns missing.
                throw new ArgumentException("The values provided do not match the expected columns");
            }

            return rows.Select(row =>
            {
                DataRow dr = table.NewRow();
                for (int i = 0; i < providedColumns.Count; i++)
                {
                    dr[providedColumns[i]] = row[i];
                }
                table.AddRow(dr);
                return dr;
            }).ToArray();
        }

        protected override object InternalVisit(ValuesInsertSource node)
        {
            return node.RowValues
                .Select(rv => Visit<object[]>(rv))
                .ToArray();
        }

        protected override object InternalVisit(RowValue node)
        {
            return node.ColumnValues
                .Select(cv => EvaluateExpression<object>(cv, Database.GlobalEnvironment))
                .ToArray();
        }
    }
}
