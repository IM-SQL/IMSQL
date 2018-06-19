using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSQL.Tools
{
    class SQLFlattenVisitor : TSqlFragmentVisitor
    {
        public SQLFlattenVisitor(TSqlFragment node)
        {
            node.Accept(this);
        }

        public List<TSqlFragment> Nodes { get; } = new List<TSqlFragment>();

        public override void Visit(TSqlFragment node)
        {
            Nodes.Add(node);
        }        
    }

    public static class Extensions
    {
        public static IEnumerable<TSqlFragment> Flatten(this TSqlFragment fragment)
        {
            return new SQLFlattenVisitor(fragment).Nodes;
        }
    }
}
