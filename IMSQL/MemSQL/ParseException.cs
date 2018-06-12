using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class ParseException : Exception
    {
        public ParseException(IEnumerable<ParseError> errors)
        {
            Errors = errors;
        }

        public IEnumerable<ParseError> Errors { get; }
    }
}
