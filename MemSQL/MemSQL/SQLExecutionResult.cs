using System;
using System.Collections.Generic;
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
    }
}
