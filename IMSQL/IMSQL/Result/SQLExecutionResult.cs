using IMSQL.DataModel.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSQL.Result
{
    public class SQLExecutionResult : SQLResult
    {
        public SQLExecutionResult(int rowsAffected, RecordTable values)
        {
            RowsAffected = rowsAffected;
            Values = values;
        }

        public int RowsAffected { get; }
        public RecordTable Values { get; }

        public override string Message => string.Format("({0} row(s) affected)", RowsAffected);

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Message);
            if (Values != null)
            {
                bool first = true;
                foreach (var item in Values.Records)
                {
                    if (first) { sb.AppendLine(); first = false; }
                    sb.AppendLine();
                    Printer.Print(item, sb);
                }
            }
            sb.AppendLine();

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
                if (value is Record)
                {
                    var items = (value as Record).ItemArray;
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
