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
    public class SQLInterpreter : SQLBaseInterpreter
    {
        public SQLInterpreter(DataSet ds) : base(ds) {}

        public int Execute(TextReader script)
        {
            var parser = new TSql140Parser(false);
            var result = parser.Parse(script, out var errors);
            if (errors.Any()) { throw new ParseException(errors); }
            Visit<object>(result);
            return 1;
        }

        public int Execute(string script)
        {
            using (var reader = new StringReader(script))
            {
                return Execute(reader);
            }
        }

        protected override object InternalVisit(CreateTableStatement node)
        {
            var createVisitor = new SQLCreateInterpreter(ds);
            return createVisitor.Visit<DataTable>(node);
        }

        protected override object InternalVisit(InsertStatement node)
        {
            SQLInsertInterpreter interpreter = new SQLInsertInterpreter(ds);
            node.Accept(interpreter);
            return null;
        }

        protected override object InternalVisit(CreateIndexStatement node)
        {
            // INFO(Richo): Do nothing
            return null;
        }
    }
}
