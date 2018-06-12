using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class ConstraintException : Exception
    {
        public ConstraintException(string message) : base(message) {}
    }
}
