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


            //TODO:This environment should be kind of global
            Environment env = new Environment();

            //this returns multiple tables because of the joins and whatever
            IEnumerable<DataTable> tables = Visit<IEnumerable<DataTable>>(node.FromClause);

            DataTable table = tables.First();

            TopResult top = Visit<TopResult>(node.TopRowFilter);
            Func<DataRow, bool> predicate = null;
            if (node.WhereClause == null)
            {
                predicate = new Func<DataRow, bool>((row) => true);
            }
            else
            {
                predicate = Visit<Func<Environment, Func<DataRow, bool>>>(node.WhereClause)(env);
            }

            List<DataRow> result = new List<DataRow>();
            result.AddRange(Filter.From(table.Rows.AsEnumerable(), predicate, top));
            return result.ToArray(); 
        }

        protected override object InternalVisit(FromClause node)
        {
            return node.TableReferences.Select(t => Visit<Tuple<string,DataTable>>(t).Item2).ToArray();
        }
    }
}