using System;
using MemSQL.DataModel.Fields;

namespace MemSQL.DataModel.Fields
{
    internal class NullableField : Field
    {
        public NullableField(string columnName, Type dataType, object value) : base(columnName, dataType, value)
        {
        }
        public NullableField(string columnName, Type dataType) : base(columnName, dataType,null)
        {
        }
        bool nullValue = false;
        public override object Value
        {
            get
            {
                if (nullValue) { return null; }
                return base.Value;
            }
            set
            {
                nullValue = value == null;
                if (value != null)
                {
                    base.Value = value;
                }
            }
        }
    }
}