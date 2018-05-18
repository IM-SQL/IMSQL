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
            int value = int.Parse(((IntegerLiteral)node.Expression).Value);
            Func<int> result = () => { return value; };
            return result;
        }
    }
}
