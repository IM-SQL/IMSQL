using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL.DataModel.Results
{
    public interface RecordTable
    {
        IEnumerable<Record> Records { get; }
        IEnumerable<RecordColumn> Columns { get; }
        string TableName { get; }
        int IndexOfColumn(string[] columnName);
    }
}
