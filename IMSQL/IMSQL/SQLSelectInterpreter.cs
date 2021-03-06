﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IMSQL.DataModel.Joins;
using IMSQL.DataModel.Results;
using IMSQL.Result;
using IMSQL.Tools;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace IMSQL
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
            //TODO:node.HavingClause
            //TODO:node.OffsetClause
            //TODO:node.OrderByClause

            var env = Database.GlobalEnvironment.NewChild();

            //this returns multiple tables because of the joins and whatever
            List<IResultTable> tables = new List<IResultTable>(Visit<IEnumerable<IResultTable>>(node.FromClause, new IResultTable[0]));

            while (tables.Count > 1)
            {
                var first = tables[0];
                tables.RemoveAt(0);
                var second = tables[0];
                tables.RemoveAt(0);
                tables.Insert(0, new CrossJoinedTable(first, second));
            }
            if (tables.Count != 0)
            {
                env.CurrentTable = tables.First();
            }

            var top = EvaluateExpression<TopResult>(node.TopRowFilter, env);
            var predicate = EvaluateExpression<Func<IResultRow, bool>>(node.WhereClause, env, row => true);

            env.CurrentTable =
                env.CurrentTable.Filter((r) => Filter.Where(r, predicate));



            //check to see if the selectors are aggregate functions.
            var grouppedData = EvaluateExpression<IResultTable>(node.GroupByClause, env, Table.Empty);
            

            var selectedColumns = node.SelectElements.SelectMany(element =>
             {
                 return EvaluateExpression<Func<IResultTable, Selector[]>>(element, env)(env.CurrentTable);
             }).ToArray();

            IResultTable result;
            var aggregates = node.SelectElements.Select(e => e.ContainsAggregate()).ToArray();

            if (aggregates.Any(e => e) || node.GroupByClause != null)
            {
                //i have aggregates.
                
                result = new RecordTable(env.CurrentTable.TableName, selectedColumns, grouppedData.Records);
            }
            else
            {
                result = new RecordTable(env.CurrentTable.TableName, selectedColumns, env.CurrentTable.Records);
            }
            if (node.UniqueRowFilter == UniqueRowFilter.Distinct)
            {
                result = result.Filter(Filter.Distinct);
            }
            if (top != null)
            {
                result = result.Filter((r) => Filter.Top(r, top));
            }
            return new SQLExecutionResult(result.Records.Count(), result);
        }

        protected override object InternalVisit(FromClause node)
        {
            return node.TableReferences.Select(t => Visit<IResultTable>(t)).ToArray();
        }

        protected override object InternalVisit(QualifiedJoin node)
        {
            //this should return a tuple of string,recordtable
            //the name will probably be null, i dont seem to have access to the alias here.
            var first = Visit<IResultTable>(node.FirstTableReference);
            var second = Visit<IResultTable>(node.SecondTableReference);

            var env = Database.GlobalEnvironment.NewChild();

            var where = new WhereClause() { SearchCondition = node.SearchCondition };
            var predicate = EvaluateExpression<Func<IResultRow, bool>>(where, env, row => true);

            if (predicate == null)
            {
                predicate = (row) => true;
            }
            if (node.QualifiedJoinType == QualifiedJoinType.Inner)
            {
                return new InnerJoinedTable(first, second, predicate);
            }
            else { return new OuterJoinedTable(node.QualifiedJoinType, first, second, predicate); }
        }
        protected override object InternalVisit(UnqualifiedJoin node)
        {
            var first = Visit<IResultTable>(node.FirstTableReference);
            var second = Visit<IResultTable>(node.SecondTableReference);
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
                return new RecordTable(node.Alias.Value, realTable.Columns, realTable.Records);
            }
            return realTable;
        }

        protected override object InternalVisit(GroupByClause node)
        {
            //node.GroupByOption
            return new Func<Environment, IResultTable>((env) =>
            {
                var selectedColumns = node.GroupingSpecifications.SelectMany(element =>
                {
                    return EvaluateExpression<Func<IResultTable, Selector[]>>(element, env)(env.CurrentTable);
                }).ToArray();

                return new RecordTable(env.CurrentTable.TableName, selectedColumns, env.CurrentTable.Records)
                .Filter(Filter.Distinct);
                
            });

        }
        protected override object InternalVisit(ExpressionGroupingSpecification node)
        {
            return
                VisitExpression<Func<IResultTable, Selector[]>>(
                new SelectScalarExpression() { Expression = node.Expression });

        }
    }
}