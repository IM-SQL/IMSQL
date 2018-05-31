using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL.DataModel.Fields
{
    class Field
    {
        protected object value; // TODO(Richo): Why protected?

        public Field(string columnName, Type dataType)
        {
            ColumnName = columnName;
            DataType = dataType;
        }

        public Field(string columnName, Type dataType, object defaultValue)
            : this(columnName, dataType)
        {
            Value = defaultValue;
        }

        public string ColumnName { get; }
        public Type DataType { get; }

        public virtual object Value
        {
            get => value;
            set => this.value = Convert.ChangeType(value, DataType);
        }
    }
}
