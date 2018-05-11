using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    internal class SQLInsertInterpreter : SQLVisitor
    {
        public SQLInsertInterpreter(DataSet ds) : base(ds)
        {
        }
    }
}
