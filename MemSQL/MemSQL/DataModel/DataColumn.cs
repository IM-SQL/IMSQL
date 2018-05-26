using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class DataColumn
    {
        public DataColumn(string columnName, Type dataType)
        {
            ColumnName = columnName;
            DataType = dataType;

            AutoIncrement = false;
            AutoIncrementSeed = 0;
            AutoIncrementStep = 0;
        }

        public DataTable Table { get; set; }
        public string ColumnName { get; }
        public Type DataType { get; }
        public bool AllowDBNull { get; set; }
        public object DefaultValue { get; set; }

        public bool Unique
        {
            get
            {
                var cols = new[] { this };
                return Table.Database.Constraints
                    .OfType<UniqueConstraint>()
                    .Where(constraint => Equals(Table, constraint.Table))
                    .Any(constraint => cols.SequenceEqual(constraint.Columns));
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
