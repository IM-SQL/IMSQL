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
        public static bool ContainsAggregate(this TSqlFragment fragment)
        {
            bool aggregate = false;
            //TODO:in the case of a subquery i should not look into it.
            SQLDynamicVisitor.Default(node => { })
                .ForType<FunctionCall>(fc =>
                {
                    if (fc.FunctionName.Value.Equals("COUNT", StringComparison.InvariantCultureIgnoreCase))
                    {
                        aggregate = true;
                    }
                })
                .Visit(fragment);
            return aggregate;
        }
        public static int GetSequenceHash<T>(this IEnumerable<T> sequence)
        {
            //code extracted from https://stackoverflow.com/questions/7278136/create-hash-value-on-a-list
            const int seed = 487;
            const int modifier = 31;
            unchecked
            {
                //TODO: i added a nullguard that may break this functionality. Tests are needed
                return sequence.Aggregate(seed, (current, item) =>
                    (current * modifier) + (item as object ?? 0).GetHashCode());
            }
        }
    }
}
