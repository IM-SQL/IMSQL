using System;
using IMSQL.DataModel.Fields;

namespace IMSQL.DataModel.Fields
{
    internal class NullableField : Field
    {
        private bool nullValue = false;

        public NullableField(string columnName, Type dataType, object value) 
            : base(columnName, dataType, value)
        { }

        public NullableField(string columnName, Type dataType) 
            : base(columnName, dataType, null)
        { }

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