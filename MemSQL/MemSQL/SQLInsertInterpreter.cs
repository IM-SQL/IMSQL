using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemSQL.DataModel.Results;
using MemSQL.Result;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace MemSQL
{
    internal class SQLInsertInterpreter : SQLBaseInterpreter
    {
        public SQLInsertInterpreter(Database db) : base(db) { }

        protected override object InternalVisit(InsertStatement node)
        {
            return Visit<SQLExecutionResult>(node.InsertSpecification);
        }

        protected override object InternalVisit(InsertSpecification node)
        {
            var table = Visit<Tuple<string, Table>>(node.Target).Item2;
            List<string> providedColumns = node.Columns
                .Select(columnReference => Visit<string>(columnReference))
                .ToList();
            var providedRows = Visit<object[][]>(node.InsertSource);
            Func<object[], Row> CreateRow;
            if (providedColumns.Count == 0)
            {
                CreateRow = row =>
                {
                    Row dr = table.NewRow(row);
                    table.AddRow(dr);
                    return dr;
                };
            }
            else
            {
                Dictionary<string, object> values = new Dictionary<string, object>();
                foreach (var item in providedColumns)
                {
                    values.Add(item, null);
                }
                CreateRow = row =>
                {
                    for (int i = 0; i < providedColumns.Count; i++)
                    {
                        values[providedColumns[i]] = row[i];
                    }   
                    Row dr = table.NewRow(values);
                    table.AddRow(dr);
                    return dr;
                };
            }
            var rows = providedRows.Select(CreateRow).ToArray();
            return new SQLExecutionResult(rows.Count(),
                ApplyOutputClause(new RecordSet(table.Columns, rows), node.OutputClause)); 
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
