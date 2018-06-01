using System;
using System.Collections.Generic;
using System.Linq;

namespace MemSQL.DataModel.Views
{
    public class RecordSet
    {
        public RecordSet(IEnumerable<Column> columns, IEnumerable<Row> rows):this(columns.Select(c=>c.GetDefaultSelector),rows)
        {

        }
        public RecordSet(IEnumerable<(string, Func<Row, object>)> selectors, IEnumerable<Row> providedRows)
        {
            var rows = providedRows.ToArray();
            //TODO:validate that the columns actually are from the rows, and that the rows are from the same table?
            //TODO: i am evaluating the expressions to infere the type, this can cause unintended sideffects.
            Selectors = selectors;
            Columns = Selectors.Select(c => new RecordColumn(c.Item1, InfereType(c.Item2, rows)));
            Records = rows.Select(r => new Record(r, this)).ToArray();
        }
        private Type InfereType(Func<Row, object> selector, IEnumerable<Row> rows)
        {
            //TODO: this type inference is flawed.
            if (rows.Count() == 0) return typeof(object);
            var data = selector(rows.First());
            if (data == null) return typeof(object);
            return data.GetType();

        }
        public IEnumerable<Record> Records { get; }
        public IEnumerable<RecordColumn> Columns { get; }
        internal IEnumerable<(string, Func<Row, object>)> Selectors { get; private set; }
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