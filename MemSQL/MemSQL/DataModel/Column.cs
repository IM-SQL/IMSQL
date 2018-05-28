using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemSQL.DataModel;
using MemSQL.DataModel.Fields;

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
        private long? identity = null;

        internal Field NewField()
        {

            if (AutoIncrement)
            {
                identity = identity.HasValue ? identity + AutoIncrementStep : AutoIncrementSeed;
                return new IdentityField(ColumnName, DataType, identity);
            }
            else if (AllowDBNull)
            {
                return new NullableField(ColumnName, DataType);
            }
            else if (DefaultValue != null)
            {
                return new Field(ColumnName, DataType, DefaultValue);
            }
            //TODO: i think we should not be able to create rows that reach this point.

            return new Field(ColumnName, DataType, GetDefault(DataType));
        
        }
        private object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
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
