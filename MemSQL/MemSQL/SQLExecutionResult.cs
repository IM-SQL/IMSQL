using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class SQLExecutionResult
    {
        public SQLExecutionResult(int rowsAffected, object value)
        {
            RowsAffected = rowsAffected;
            Value = value;
        }

        public int RowsAffected { get; }
        public object Value { get; }

        public override string ToString()
        {
            return string.Format("Rows affected: {0}\r\n{1}", RowsAffected, FormattedValue);
        }

        private string FormattedValue
        {
            get
            {
                // TODO(Richo): HACK!
                if (Value is DataRow[])
                {
                    StringBuilder sb = new StringBuilder();
                    var rows = Value as DataRow[];
                    for (int i = 0; i < rows.Length; i++)
                    {
                        var row = rows[i];
                        if (i > 0) { sb.AppendLine(); }
                        var items = row.ItemArray.Select(item =>
                        {
                            if (item == null || item == DBNull.Value) return "NULL";
                            if (item is string) return "'" + item + "'";

                            return item.ToString();
                        });
                        sb.AppendFormat("({0})", string.Join(", ", items));
                    }
                    return sb.ToString();
                }
                else
                {
                    return Value.ToString();
                }
            }
        }
    }
}
