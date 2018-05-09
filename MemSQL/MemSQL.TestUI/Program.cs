using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL.TestUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Microsoft.SqlServer.TransactSql.ScriptDom.TSql140Parser parser = new Microsoft.SqlServer.TransactSql.ScriptDom.TSql140Parser(false);

            var reader = new StringReader("Insert into tbl(A,B,C) values (SCOPE_IDENTITY() ,@@Identity,@P)"); 
            var result = parser.Parse(reader,out var error);
            Console.ReadLine();
        }
    }
}
