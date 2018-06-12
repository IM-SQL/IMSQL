using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSQL.DataModel.Results
{
    public interface IResultTable
    {
        IEnumerable<IResultRow> Records { get; }
        IEnumerable<ResultColumn> Columns { get; }
        string TableName { get; }
        int IndexOfColumn(string[] columnName);
    }
}
