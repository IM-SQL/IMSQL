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

        public int Execute(TextReader script)
        {
            var parser = new TSql140Parser(false);
            var result = parser.Parse(script, out var errors);
            if (errors.Any()) { throw new ParseException(errors); }
            result.Accept(this);
            return 1;
        }

        public int Execute(string script)
        {
            using (var reader = new StringReader(script))
            {
                return Execute(reader);
            }
        }

        public override void ExplicitVisit(CreateTableStatement node)
        {
            var createVisitor = new SQLCreateInterpreter(ds);
            createVisitor.Visit<DataTable>(node);
        }

        public override void ExplicitVisit(InsertStatement node)
        {
            SQLInsertInterpreter interpreter = new SQLInsertInterpreter(ds);
            node.Accept(interpreter);
        }

        public override void ExplicitVisit(CreateIndexStatement node)
        {
            // INFO(Richo): Do nothing
        }
    }
}
