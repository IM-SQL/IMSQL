using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSQL
{
    static class Extensions
    {
        public static string AsString(this TSqlFragment fragment, int from, int to)
        {
            //TODO: bounds check.
            StringBuilder sb = new StringBuilder();
            for (int i = from; i <= to; i++)
            {
                sb.Append(fragment.ScriptTokenStream[i].Text);
            }
            return sb.ToString();
        }
    }
}
