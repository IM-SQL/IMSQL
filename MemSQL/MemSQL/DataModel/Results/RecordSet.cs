using System;
using System.Collections.Generic;
using System.Linq;

namespace MemSQL.DataModel.Results
{
    public class RecordSet : RecordTable
    {
        internal RecordSet() { }
        public RecordSet(IEnumerable<RecordColumn> columns, IEnumerable<Record> records)
        {
            Records = records;
            Columns = columns;
        }

        public RecordSet(IEnumerable<Column> columns, IEnumerable<Row> rows)
            : this(columns.Select(c => c.GetDefaultSelector), rows)
        { }

        public RecordSet(IEnumerable<(string, Func<Record, object>)> selectors, IEnumerable<Record> providedRows)
        {
            var rows = providedRows.ToArray();
            //TODO:validate that the columns actually are from the rows, and that the rows are from the same table?
            //TODO: i am evaluating the expressions to infere the type, this can cause unintended sideffects.
            Selectors = selectors;
            Columns = Selectors.Select(c => new RecordColumn(c.Item1, InfereType(c.Item2, rows))).ToArray();
            Records = rows.Select(r => new RowRecord(r, this)).ToArray();
        }

        private Type InfereType(Func<Record, object> selector, IEnumerable<Record> rows)
        {
            //TODO: this type inference is flawed.
            if (rows.Count() == 0) return typeof(object);
            var data = selector(rows.First());
            if (data == null) return typeof(object);
            return data.GetType();
        }

        public IEnumerable<Record> Records { get; protected set; }
        public IEnumerable<RecordColumn> Columns { get; protected set; }
        internal IEnumerable<(string, Func<Record, object>)> Selectors { get; private set; }

        IEnumerable<Record> RecordTable.Records => Records;

        public virtual int IndexOfColumn(string[] name)
        {
            int result = -1;
            foreach (var item in Columns)
            {
                result++;
                if (item.ColumnName == name.Last())
                {
                    return result;
                }
            }
            throw new KeyNotFoundException();
        }
    }
}