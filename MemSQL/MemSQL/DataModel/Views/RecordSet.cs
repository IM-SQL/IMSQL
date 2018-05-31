using System;
using System.Collections.Generic;
using System.Linq;

namespace MemSQL.DataModel.Views
{
    public class RecordSet
    {
        public RecordSet(IEnumerable<Column> columns, IEnumerable<Row> rows)
        {
            //TODO:validate that the columns actually are from the rows, and that the rows are from the same table?
            Columns = columns.Select(c => new RecordColumn(c)).ToArray();
            Records = rows.Select(r => new Record(r, this));
        }

        public IEnumerable<Record> Records { get; }
        public IEnumerable<RecordColumn> Columns { get; }

        internal int IndexOfColumn(string name)
        {
            int result = -1;
            foreach (var item in Columns)
            {
                result++;
                if (item.ColumnName == name)
                {
                    return result;
                }
            }
             throw new KeyNotFoundException();
        }

        public RecordSet(IEnumerable<RecordColumn> columns, IEnumerable<Record> records)
        {
            Records = records;
            Columns = columns;
        }
    }
}