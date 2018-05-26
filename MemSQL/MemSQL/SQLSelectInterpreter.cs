using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace MemSQL
{
    internal class SQLSelectInterpreter : SQLBaseInterpreter
    {
        public SQLSelectInterpreter(Database db) : base(db) {}

        protected override object InternalVisit(SelectStatement node)
        {
            //TODO:node.ComputeClauses
            //TODO:node.Into
            //TODO:node.On
            //TODO:node.OptimizerHints
            //TODO:node.QueryExpression
            //TODO:node.WithCtesAndXmlNamespaces
            return Visit<DataRow[]>(node.QueryExpression);
        }

        protected override object InternalVisit(QuerySpecification node)
        {
            //TODO:node.ForClause
            //TODO:node.FromClause
            //TODO:node.GroupByClause
            //TODO:node.HavingClause
            //TODO:node.OffsetClause
            //TODO:node.OrderByClause
            //TODO:node.SelectElements 
            //TODO:node.UniqueRowFilter 

            var env = Database.GlobalEnvironment.NewChild();

            //this returns multiple tables because of the joins and whatever
            IEnumerable<DataTable> tables = Visit<IEnumerable<DataTable>>(node.FromClause);
            DataTable table = tables.First();
            var top = EvaluateExpression<TopResult>(node.TopRowFilter, env);
            var predicate = EvaluateExpression<Func<DataRow, bool>>(node.WhereClause, env, row => true);

            return Filter.From(table.Rows, predicate, top).ToArray();
        }

        protected override object InternalVisit(FromClause node)
        {
            return node.TableReferences.Select(t => Visit<Tuple<string,DataTable>>(t).Item2).ToArray();
        }
    }
}