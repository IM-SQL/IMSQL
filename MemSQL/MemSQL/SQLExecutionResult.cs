using MemSQL.DataModel.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class SQLExecutionResult
    {
        public SQLExecutionResult(int rowsAffected, RecordSet[] values)
        {
            RowsAffected = rowsAffected;
            Values = values;
        }

        public int RowsAffected { get; }
        public RecordSet[] Values { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Rows affected: ");
            sb.Append(RowsAffected);
            sb.AppendLine();
            bool first = true;
            foreach (var set in Values)
            {
                sb.AppendLine();
                foreach (var item in set.Records)
                {
                    if (first) { sb.AppendLine(); first = false; }
                    sb.AppendLine();
                    Printer.Print(item, sb);
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        /// <summary>
        /// TODO(Richo): HACK! This class is just a temporary hack in order to show the execution results a 
        /// little nicer. We might be able to get rid of it when we implement printing in our own data model.
        /// </summary>
        private static class Printer
        {
            public static void Print(object value, StringBuilder sb)
            {
                if (value is Row)
                {
                    var items = (value as Row).ItemArray;
                    sb.Append("(");
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (i > 0) { sb.Append(", "); }
                        Print(items[i], sb);
                    }
                    sb.Append(")");
                }
                else if (value == null)
                {
                    sb.Append("NULL");
                }
                else if (value is string)
                {
                    sb.Append("'");
                    sb.Append(value);
                    sb.Append("'");
                }
                else if (value is DateTime)
                {
                    sb.Append("'");
                    sb.Append(((DateTime)value).ToString("o"));
                    sb.Append("'");
                }
                else if (value is IEnumerable)
                {
                    var items = value as IEnumerable;
                    int i = 0;
                    foreach (var item in items)
                    {
                        if (i > 0) { sb.AppendLine(); }
                        Print(item, sb);
                        i++;
                    }
                }
                else
                {
                    sb.Append(value);
                }
            }
        }
    }
}
