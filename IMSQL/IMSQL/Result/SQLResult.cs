using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSQL.Result
{
    public abstract class SQLResult
    {
        public abstract string Message { get; }

        public override string ToString()
        {
            return Message;
        }
    }
}
