using System;

namespace MemSQL.DataModel.Results
{
    public class ResultColumn
    {
        public ResultColumn(string name, Type type)
        {
            ColumnName = name;
            DataType = type;
        }

        public string ColumnName { get; }
        public Type DataType { get; }
        internal (string, Func<IResultRow, object>) GetDefaultSelector { get { return (ColumnName, new Func<IResultRow, object>(r => r[ColumnName])); } }

    }
}