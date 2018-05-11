using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{ 
    public class SQLInterpreter : SQLVisitor
    {

        public SQLInterpreter(DataSet ds):base(ds)
        {
        }

        public int Execute(string script)
        {
            var parser = new TSql140Parser(false);
            TSqlScript result = (TSqlScript)parser.Parse(new StringReader(script), out var errors);
            //TODO: throw errors.
            foreach (var batch in result.Batches)
            {
                ExplicitVisit(batch);
            }
            return 1;
        }

        public override void ExplicitVisit(CreateTableStatement node)
        {
            SQLCreateInterpreter createVisitor = new SQLCreateInterpreter(ds);
            node.Accept(createVisitor);
       
        }

        public override void ExplicitVisit(InsertStatement node)
        {
            SQLInsertInterpreter interpreter = new SQLInsertInterpreter(ds);
            node.Accept(interpreter);
        }


    }
}
