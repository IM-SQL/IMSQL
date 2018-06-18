using System;
using System.Collections.Generic;
using System.Linq;

namespace IMSQL.DataModel.Results
{
    public class RecordTable : IResultTable
    {
        internal RecordTable() { }
        public RecordTable(string name, IEnumerable<ResultColumn> columns, IEnumerable<IResultRow> records)
        {
            TableName = name;
            Records = records.Select(r => r.Wrap(this));
            Columns = columns;
        }

        public RecordTable(string name, IEnumerable<Column> columns, IEnumerable<Row> rows)
            : this(name, columns.Select(c => c.GetDefaultSelector), rows)
        { }

        public RecordTable(string name, IEnumerable<Selector> selectors, IEnumerable<IResultRow> providedRows)
        {
            TableName = name;
            var rows = providedRows.ToArray();
            //TODO:validate that the columns actually are from the rows, and that the rows are from the same table?
            //TODO: i am evaluating the expressions to infere the type, this can cause unintended sideffects.
            Selectors = selectors;
            Columns = Selectors.Select(c => new ResultColumn(c.OutputName, InfereType(c.GetValueFrom, rows))).ToArray();
            Records = rows.Select(r => new Record(r, this)).ToArray();
        }

        private Type InfereType(Func<IResultRow, object> selector, IEnumerable<IResultRow> rows)
        {
            //TODO: this type inference is flawed.
            if (rows.Count() == 0) return typeof(object);
            var data = selector(rows.First());
            if (data == null) return typeof(object);
            return data.GetType();
        }

        public IEnumerable<IResultRow> Records { get; protected set; }
        public IEnumerable<ResultColumn> Columns { get; protected set; }
        internal IEnumerable<Selector> Selectors { get; private set; }

        IEnumerable<IResultRow> IResultTable.Records => Records;

        public string TableName
        {
            get;
            set;
        }

        public virtual int IndexOfColumn(string[] name)
        {
            if (name.Length == 2)
            {
                if (TableName != "" && !string.Equals(TableName, name[0], StringComparison.InvariantCultureIgnoreCase))
                { return -1; }
            }
            int result = -1;
            foreach (var item in Columns)
            {
                result++;
                if (item.ColumnName.Equals(name.Last(), StringComparison.InvariantCultureIgnoreCase))
                {
                    return result;
                }
            }
            return -1;
        }
    }
}