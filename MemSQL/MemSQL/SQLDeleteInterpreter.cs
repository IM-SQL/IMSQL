using System;
using System.Data;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace MemSQL
{
    internal class SQLDeleteInterpreter : SQLBaseInterpreter
    {
        public SQLDeleteInterpreter(DataSet ds) : base(ds)
        {
        }

        protected override object InternalVisit(DeleteStatement node)
        {
            throw new NotImplementedException();
        }
    }
}