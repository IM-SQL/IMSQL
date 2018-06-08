
using MemSQL.DataModel.Results;
using MemSQL.Result;
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
        public SQLInterpreter() : this(new Database()) { }
        public SQLInterpreter(Database db) : base(db) { }

        public SQLExecutionResult[] Execute(TextReader script)
        {
            var parser = new TSql140Parser(false);
            var parseResult = parser.Parse(script, out var errors);
            if (errors.Any()) { throw new ParseException(errors); }
            return Visit<SQLExecutionResult[]>(parseResult);
        }

        public SQLExecutionResult[] Execute(string script)
        {
            using (var reader = new StringReader(script))
            {
                return Execute(reader);
            }
        }

        protected override object InternalVisit(TSqlScript node)
        {
            return VisitCollection<SQLExecutionResult[]>(node.Batches).SelectMany(each => each).ToArray();
        }

        protected override object InternalVisit(TSqlBatch node)
        {
            return VisitCollection<SQLExecutionResult>(node.Statements).ToArray();
        }

        protected override object InternalVisit(CreateTableStatement node)
        {
            var interpreter = new SQLCreateInterpreter(Database);
            var table = interpreter.Visit<RecordTable>(node);
            //TODO: we should have result subtypes, SQL returns "Command(s) completed successfully." on this case, and it does not return a reference or data of the created table
            return new SQLExecutionResult(0, null);
        }

        protected override object InternalVisit(InsertStatement node)
        {
            var interpreter = new SQLInsertInterpreter(Database);
            return interpreter.Visit<SQLExecutionResult>(node);
        }

        protected override object InternalVisit(CreateIndexStatement node)
        {
            // INFO(Richo): Do nothing
            return null;
        }

        protected override object InternalVisit(SelectStatement node)
        {
            var interpreter = new SQLSelectInterpreter(Database);
            return interpreter.Visit<SQLExecutionResult>(node);
        }

        protected override object InternalVisit(DeleteStatement node)
        {
            var interpreter = new SQLDeleteInterpreter(Database);
            return interpreter.Visit<SQLExecutionResult>(node);
        }

        protected override object InternalVisit(UpdateStatement node)
        {
            var interpreter = new SQLUpdateInterpreter(Database);
            return interpreter.Visit<SQLExecutionResult>(node);
        }
    }
}
