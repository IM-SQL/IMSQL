using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace IMSQL.DataModel
{
    public class CallSpecification
    { 
        public CallSpecification(FunctionCall node, IEnumerable<Func<Environment, object>> parameters)
        {
            UniqueRowFilter = node.UniqueRowFilter;
            Parameters = parameters;
        }

        public UniqueRowFilter UniqueRowFilter { get; internal set; }
        public IEnumerable<Func<Environment, object>> Parameters { get; }
    }
}
