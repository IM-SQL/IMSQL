using System;

namespace IMSQL.DataModel.Results
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
        internal Selector GetDefaultSelector
        {
            get
            {
                return
                    new Selector(ColumnName,
                    new Func<IResultRow, object>(r => r[ColumnName]));
            }
        }

    }
}