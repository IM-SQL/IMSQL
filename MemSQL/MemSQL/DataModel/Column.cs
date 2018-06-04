using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemSQL.DataModel;
using MemSQL.DataModel.Fields;
using MemSQL.DataModel.Results;

namespace MemSQL
{
    public class Column : RecordColumn
    {
        private long? identity = null;

        public Column(string columnName, Type dataType) : base(columnName, dataType)
        {
            AllowDBNull = true;
            AutoIncrement = false;
            AutoIncrementSeed = 0;
            AutoIncrementStep = 0;
        }

        public Table Table { get; set; }


        public bool AllowDBNull { get; set; }

        public object DefaultValue { get; set; }

        public bool AutoIncrement { get; set; }
        public long AutoIncrementStep { get; set; }
        public long AutoIncrementSeed { get; set; }

        public Func<Row, object> ComputedColumnSpecification { get; set; }

        internal Field NewField(object providedValue, Row owner)
        {
            if (AutoIncrement)
            {
                throw new InvalidOperationException("Cannot insert explicit value for identity column");
            }
            else if (ComputedColumnSpecification != null)
            {
                throw new InvalidOperationException("Cannot insert explicit value for a calculated column");
            }
            else if (AllowDBNull)
            {
                return new NullableField(ColumnName, DataType, providedValue);
            }
            else if (providedValue == null)
            {
                throw new ArgumentException(string.Format("A value for the field {0} should not have been provided", ColumnName));
            }
            return new Field(ColumnName, DataType, providedValue);
        }

        internal Field NewField(Row owner)
        {
            if (AutoIncrement)
            {
                identity = identity.HasValue ? identity + AutoIncrementStep : AutoIncrementSeed;
                return new IdentityField(ColumnName, DataType, identity);
            }
            else if (ComputedColumnSpecification != null)
            {
                return new CalculatedField(ColumnName, DataType, ComputedColumnSpecification, owner);
            }
            else if (DefaultValue != null)
            {
                return new Field(ColumnName, DataType, DefaultValue);
            }
            else if (AllowDBNull)
            {
                return new NullableField(ColumnName, DataType);
            }
            throw new ArgumentException(string.Format("A value for the field {0} should not have been provided", ColumnName));
        }

        private object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }

        public bool Unique
        {
            get
            {
                var cols = new[] { this };
                return Table.UniqueConstraints.Any(c => cols.SequenceEqual(c.Columns));
            }
        }

        internal (string, Func<Row, object>) GetDefaultSelector { get { return (ColumnName, new Func<Row, object>(r => r[ColumnName])); } }

        public override string ToString()
        {
            return string.Format("{0} ({1})", base.ToString(), ColumnName);
        }
    }
}
