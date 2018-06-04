using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL.DataModel.Results
{
    public interface Record
    {
        object this[string name] { get; }
        object[] ItemArray { get; }
    }
}
