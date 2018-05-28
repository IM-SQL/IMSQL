using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL.DataModel.Fields
{
    class Field
    {
        private string columnName;
        private Type dataType;
        protected object value;

        public Field(string columnName, Type dataType, object defaultValue)
        {
            this.columnName = columnName;
            this.dataType = dataType;
            this.Value = defaultValue;
        }

        public virtual object Value {  get => value;  set => this.value = Convert.ChangeType(value, DataType); }
        public Type DataType { get => dataType; }
        public string ColumnName { get => columnName; }
    }
}
