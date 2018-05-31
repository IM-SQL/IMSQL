using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MemSQL.DataModel.Views;
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
            //TODO:node.QueryExpression
            //TODO:node.WithCtesAndXmlNamespaces
            return Visit<RecordSet>(node.QueryExpression);
        }

        protected override object InternalVisit(QuerySpecification node)
        {
            //TODO:node.ForClause 
            //TODO:node.GroupByClause
            //TODO:node.HavingClause
            //TODO:node.OffsetClause
            //TODO:node.OrderByClause
            //TODO:node.SelectElements 
            //TODO:node.UniqueRowFilter 

            var env = Database.GlobalEnvironment.NewChild();

            //this returns multiple tables because of the joins and whatever
            IEnumerable<Table> tables = Visit<IEnumerable<Table>>(node.FromClause);
            Table table = tables.First();
            var top = EvaluateExpression<TopResult>(node.TopRowFilter, env);
            var predicate = EvaluateExpression<Func<Row, bool>>(node.WhereClause, env, row => true);


            //TODO: the selected fields i get as expressions, i do not want an expression there for now.
            IEnumerable<Column> selectedColumns = table.Columns;
            if (node.SelectElements != null)
            {
                selectedColumns = node.SelectElements.SelectMany(element =>
                {
                    return EvaluateExpression<Func<Table, Column[]>>(element, env)(table);
                }).ToArray();
            }

            return new RecordSet(selectedColumns, Filter.From(table.Rows, predicate, top));
        }

        protected override object InternalVisit(FromClause node)
        {
            return node.TableReferences.Select(t => Visit<Tuple<string, Table>>(t).Item2).ToArray();
        }

        protected override object InternalVisit(SelectStarExpression node)
        {
            return new Func<Environment, object>(env =>
            {
                return new Func<Table, Column[]>(table =>
                {
                    return table.Columns.ToArray();
                });
            });
        }

        protected override object InternalVisit(SelectScalarExpression node)
        {
            return new Func<Environment, object>(env =>
            {
                return new Func<Table, Column[]>(table =>
                {
                    // TODO(Richo): node.ColumnName ?

                    string columnName = Visit<string>(node.Expression);
                    return new[] { table.GetColumn(columnName) };
                });
            });
        }
    }
}