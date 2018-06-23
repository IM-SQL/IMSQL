using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSQL.Tools
{
    public class SQLDynamicVisitor
    {
        public static SQLDynamicVisitor Default(Action<TSqlFragment> defaultAction)
        {
            return new SQLDynamicVisitor(defaultAction);
        }
        
        private Action<TSqlFragment> defaultAction;
        private Dictionary<Type, Action<TSqlFragment>> dispatchTable;

        private SQLDynamicVisitor(Action<TSqlFragment> defaultAction)
            : this(defaultAction, new Dictionary<Type, Action<TSqlFragment>>())
        {}

        private SQLDynamicVisitor(Action<TSqlFragment> defaultAction, Dictionary<Type, Action<TSqlFragment>> dispatchTable)
        {
            this.defaultAction = defaultAction;
            this.dispatchTable = dispatchTable;
        }

        public SQLDynamicVisitor ForType<T>(Action<T> action) where T : TSqlFragment
        {
            var table = new Dictionary<Type, Action<TSqlFragment>>(dispatchTable);
            table[typeof(T)] = node => action(node as T);
            return new SQLDynamicVisitor(defaultAction, table);
        }

        public void Visit(TSqlFragment node)
        {
            var visitor = new SQLInternalVisitor(this);
            node.Accept(visitor);            
        }

        private Action<TSqlFragment> Lookup(Type type)
        {
            Action<TSqlFragment> action;
            if (!dispatchTable.TryGetValue(type, out action))
            {
                if (type.Equals(typeof(TSqlFragment)))
                {
                    return defaultAction;
                }
                else
                {
                    return Lookup(type.BaseType);
                }
            }
            return action;
        }

        class SQLInternalVisitor : TSqlFragmentVisitor
        {
            private SQLDynamicVisitor outer;

            public SQLInternalVisitor(SQLDynamicVisitor outer)
            {
                this.outer = outer;
            }

            public override void Visit(TSqlFragment node)
            {
                Action<TSqlFragment> action = outer.Lookup(node.GetType());
                action(node);
            }
        }
    }
}
