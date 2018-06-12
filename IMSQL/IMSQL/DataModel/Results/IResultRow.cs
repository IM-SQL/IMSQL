using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSQL.DataModel.Results
{
    public interface IResultRow
    {
        object this[params string[] name] { get; }
        object[] ItemArray { get; }

        IResultRow Wrap(RecordTable recordSet);
    }
}
