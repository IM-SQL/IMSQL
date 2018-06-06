using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MemSQL.DataModel.Joins;
using MemSQL.DataModel.Results;
using MemSQL.Result;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace MemSQL
{
    internal class SQLSelectInterpreter : SQLBaseInterpreter
    {
        public SQLSelectInterpreter(Database db) : base(db) { }

        protected override object InternalVisit(SelectStatement node)
        {
            //TODO:node.ComputeClauses
            //TODO:node.Into
            //TODO:node.On
            //TODO:node.OptimizerHints
            //TODO:node.WithCtesAndXmlNamespaces
            return Visit<SQLExecutionResult>(node.QueryExpression);
        }

        protected override object InternalVisit(QuerySpecification node)
        {
            //TODO:node.ForClause 
            //TODO:node.GroupByClause
            //TODO:node.HavingClause
            //TODO:node.OffsetClause
            //TODO:node.OrderByClause
            //TODO:node.UniqueRowFilter 

            var env = Database.GlobalEnvironment.NewChild();

            //this returns multiple tables because of the joins and whatever
            IEnumerable<RecordTable> tables = Visit<IEnumerable<RecordTable>>(node.FromClause);
            if (tables == null)
            {
                tables = new Table[] { Table.Empty };
            }
            RecordTable table = tables.First();

            var top = EvaluateExpression<TopResult>(node.TopRowFilter, env);
            var predicate = EvaluateExpression<Func<Record, bool>>(node.WhereClause, env, row => true);


            var selectedColumns = node.SelectElements.SelectMany(element =>
             {
                 return EvaluateExpression<Func<RecordTable, (string, Func<Record, object>)[]>>(element, env)(table);
             }).ToArray();

            var result = new RecordSet(table.TableName,selectedColumns, Filter.From(table.Records, predicate, top));

            return new SQLExecutionResult(result.Records.Count(), result);
        }

        protected override object InternalVisit(FromClause node)
        {
            return node.TableReferences.Select(t => Visit<(string, RecordTable)>(t).Item2).ToArray();
        }
        protected override object InternalVisit(QualifiedJoin node)
        {
            //this should return a tuple of string,recordtable
            //the name will probably be null, i dont seem to have access to the alias here.
            var first = Visit<(string, RecordTable)>(node.FirstTableReference);
            var second = Visit<(string, RecordTable)>(node.SecondTableReference);

            var env = Database.GlobalEnvironment.NewChild();
             
            var where = new WhereClause() { SearchCondition = node.SearchCondition };
            var predicate = EvaluateExpression<Func<Record, bool>>(where, env, row => true);

            if (predicate == null)
            {
                predicate = (row) => true;
            }
            return ("", (RecordTable)new InnerJoinTable(first, second, predicate));
        }
    }
}