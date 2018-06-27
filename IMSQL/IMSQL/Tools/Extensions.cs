using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSQL.Tools
{
    public static class Extensions
    {
        public static IEnumerable<TSqlFragment> Flatten(this TSqlFragment fragment)
        {
            var nodes = new List<TSqlFragment>();
            SQLDynamicVisitor.Default(node => nodes.Add(node)).Visit(fragment);
            return nodes;
        }
        public static bool ContainsAggregate(this TSqlFragment fragment) {
            bool aggregate = false;
            //TODO:in the case of a subquery i should not look into it.
            SQLDynamicVisitor.Default(node => { })
                .ForType<FunctionCall>(fc => {
                    if (fc.FunctionName.Value.Equals("COUNT", StringComparison.InvariantCultureIgnoreCase))
                    {
                        aggregate = true;
                    }
                })
                .Visit(fragment);
            return aggregate;
        }
    }
}
