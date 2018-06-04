using System;

namespace MemSQL.DataModel.Results
{
    public class RecordColumn
    {
        public RecordColumn(string name, Type type)
        {
            ColumnName = name;
            DataType = type;
        }

        public string ColumnName { get; }
        public Type DataType { get; }
        internal (string, Func<Record, object>) GetDefaultSelector { get { return (ColumnName, new Func<Record, object>(r => r[ColumnName])); } }

    }
}