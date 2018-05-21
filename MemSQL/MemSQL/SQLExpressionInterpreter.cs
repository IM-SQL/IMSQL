using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace MemSQL
{
    internal class SQLExpressionInterpreter : SQLBaseInterpreter
    {
        public SQLExpressionInterpreter(DataSet ds) : base(ds)
        {
        }
        protected override object InternalVisit(ParenthesisExpression node)
        {
            //      return InternalVisit(node.Expression);

            //TODO: here i should use node.scalarExpression.accept(this) to build a correct expression.
            return Visit<object>(node.Expression);
        }

        protected override object InternalVisit(IntegerLiteral node)
        {
            return new Func<object>( () => { return int.Parse(node.Value); });
        }

        protected override object InternalVisit(StringLiteral node)
        {
            return new Func<object>(() => { return node.Value.ToString(); });
        }

        protected override object InternalVisit(NullLiteral node)
        {
            return new Func<object>(() => { return DBNull.Value; });
        }
    }
}
