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
            List<RecordTable> tables = new List<RecordTable>(Visit<IEnumerable<RecordTable>>(node.FromClause,new RecordTable[0]));
            if (tables.Count == 0)
            {
                tables.Add(Table.Empty);
            }
            while (tables.Count > 1)
            {
                var first = tables[0];
                tables.RemoveAt(0);
                var second = tables[0];
                tables.RemoveAt(0);
                tables.Insert(0, new CrossJoinedTable(first, second));
            }
            RecordTable table = tables.First();

            var top = EvaluateExpression<TopResult>(node.TopRowFilter, env);
            var predicate = EvaluateExpression<Func<Record, bool>>(node.WhereClause, env, row => true);


            var selectedColumns = node.SelectElements.SelectMany(element =>
             {
                 return EvaluateExpression<Func<RecordTable, (string, Func<Record, object>)[]>>(element, env)(table);
             }).ToArray();

            //i need to apply the selectors before the filter, this ensures me that i apply the alias in the columns
            var result = new RecordSet(table.TableName, table.Columns, Filter.From(table.Records, predicate, top));
            //TODO: ensure that a select with a where that is not present on the result works.
            result = new RecordSet(result.TableName, selectedColumns, result.Records);
            return new SQLExecutionResult(result.Records.Count(), result);
        }

        protected override object InternalVisit(FromClause node)
        {
            return node.TableReferences.Select(t => Visit<RecordTable>(t)).ToArray();
        }

        protected override object InternalVisit(QualifiedJoin node)
        {
            //this should return a tuple of string,recordtable
            //the name will probably be null, i dont seem to have access to the alias here.
            var first = Visit<RecordTable>(node.FirstTableReference);
            var second = Visit<RecordTable>(node.SecondTableReference);

            var env = Database.GlobalEnvironment.NewChild();

            var where = new WhereClause() { SearchCondition = node.SearchCondition };
            var predicate = EvaluateExpression<Func<Record, bool>>(where, env, row => true);

            if (predicate == null)
            {
                predicate = (row) => true;
            }
            return new InnerJoinedTable(first, second, predicate);
        }
        protected override object InternalVisit(UnqualifiedJoin node)
        {
            var first = Visit<RecordTable>(node.FirstTableReference);
            var second = Visit<RecordTable>(node.SecondTableReference);
            switch (node.UnqualifiedJoinType)
            {
                case UnqualifiedJoinType.CrossJoin:
                    return new CrossJoinedTable(first, second);
                case UnqualifiedJoinType.CrossApply:
                case UnqualifiedJoinType.OuterApply:
                default:
                    throw new NotImplementedException();
            }
        }
        protected override object InternalVisit(QueryDerivedTable node)
        {
            var realTable = Visit<SQLExecutionResult>(node.QueryExpression).Values;

            if (node.Alias != null)
            {
                return new RecordSet(node.Alias.Value, realTable.Columns, realTable.Records);
            }
            return realTable;
        }
    }
}