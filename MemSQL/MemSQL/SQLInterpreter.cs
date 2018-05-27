﻿using Microsoft.SqlServer.TransactSql.ScriptDom;
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
        public SQLInterpreter() : this(new Database()) {}
        public SQLInterpreter(Database db) : base(db) {}

        public SQLExecutionResult Execute(TextReader script)
        {
            var parser = new TSql140Parser(false);
            var parseResult = parser.Parse(script, out var errors);
            if (errors.Any()) { throw new ParseException(errors); }
            return Visit<SQLExecutionResult>(parseResult);
        }

        public SQLExecutionResult Execute(string script)
        {
            using (var reader = new StringReader(script))
            {
                return Execute(reader);
            }
        }

        protected override object InternalVisit(TSqlScript node)
        {
            var results = VisitCollection<Tuple<int, object>[]>(node.Batches).SelectMany(each => each);
            return new SQLExecutionResult(
                rowsAffected: results.Sum(tuple => tuple.Item1),
                values: results.Select(tuple => tuple.Item2).ToArray());
        }

        protected override object InternalVisit(TSqlBatch node)
        {
            return VisitCollection<Tuple<int, object>>(node.Statements).ToArray();
        }

        protected override object InternalVisit(CreateTableStatement node)
        {
            var interpreter = new SQLCreateInterpreter(Database);
            var table = interpreter.Visit<Table>(node);
            return new Tuple<int, object>(0, table);
        }

        protected override object InternalVisit(InsertStatement node)
        {
            var interpreter = new SQLInsertInterpreter(Database);
            var rows = interpreter.Visit<Row[]>(node);
            return new Tuple<int, object>(rows.Length, rows);
        }

        protected override object InternalVisit(CreateIndexStatement node)
        {
            // INFO(Richo): Do nothing
            return null;
        }

        protected override object InternalVisit(SelectStatement node)
        {
            var interpreter = new SQLSelectInterpreter(Database);
            var rows = interpreter.Visit<Row[]>(node);
            return new Tuple<int, object>(rows.Length, rows);
        }

        protected override object InternalVisit(DeleteStatement node)
        {
            var interpreter = new SQLDeleteInterpreter(Database);
            var rows = interpreter.Visit<Row[]>(node);
            return new Tuple<int, object>(rows.Length, rows);
        }

        protected override object InternalVisit(UpdateStatement node)
        {
            var interpreter = new SQLUpdateInterpreter(Database);
            var rows = interpreter.Visit<Row[]>(node);
            return new Tuple<int, object>(rows.Length, rows); 
        }
    }
}
