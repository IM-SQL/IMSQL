using System;
using MemSQL.DataModel.Fields;

namespace MemSQL.DataModel.Fields
{
    internal class NullableField : Field
    {
        public NullableField(string columnName, Type dataType, object value) : base(columnName, dataType, value)
        {
        }
        public NullableField(string columnName, Type dataType) : base(columnName, dataType, DBNull.Value)
        {
        }
        bool nullValue = false;
        public override object Value
        {
            get
            {
                if (nullValue) { return DBNull.Value; }
                return base.Value;
            }
            set
            {
                nullValue = value == DBNull.Value;
                if (value != DBNull.Value)
                {
                    base.Value = value;
                }
            }
        }
    }
}