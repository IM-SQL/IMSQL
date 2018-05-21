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
            return Visit<object>(node.Expression);
        }


    }
}
