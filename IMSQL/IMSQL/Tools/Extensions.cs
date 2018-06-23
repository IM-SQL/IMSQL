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
    }
}
