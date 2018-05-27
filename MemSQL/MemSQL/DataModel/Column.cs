using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class Column
    {
        public Column(string columnName, Type dataType)
        {
            ColumnName = columnName;
            DataType = dataType;

            AutoIncrement = false;
            AutoIncrementSeed = 0;
            AutoIncrementStep = 0;
        }

        public Table Table { get; set; }
        public string ColumnName { get; }
        public Type DataType { get; }
        public bool AllowDBNull { get; set; }
        public object DefaultValue { get; set; }

        public bool Unique
        {
            get
            {
                var cols = new[] { this };
                return Table.UniqueConstraints.Any(c => cols.SequenceEqual(c.Columns));
            }
        }

        public bool AutoIncrement { get; set; }
        public long AutoIncrementStep { get; set; }
        public long AutoIncrementSeed { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", base.ToString(), ColumnName);
        }
    }
}
