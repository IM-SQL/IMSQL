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
                    foreach (var row in Value as DataRow[])
                    {
                        sb.AppendFormat("({0})", string.Join(", ", row.ItemArray));
                        sb.AppendLine();
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
