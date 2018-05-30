using System;

namespace MemSQL.DataModel.Views
{
    public class RecordColumn
    {
        public RecordColumn(Column c)
        {
            ColumnName = c.ColumnName;
            DataType = c.DataType;
        }

        public string ColumnName { get; private set; }
        public Type DataType { get; private set; }


    }
}