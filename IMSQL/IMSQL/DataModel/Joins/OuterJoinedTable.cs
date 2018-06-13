using IMSQL.DataModel.Results;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSQL.DataModel.Joins
{
    class OuterJoinedTable : RecordTable
    {
        private IResultTable first;
        private IResultTable second;
        private QualifiedJoinType joinType;

        public OuterJoinedTable(QualifiedJoinType joinType, IResultTable first, IResultTable second, Func<IResultRow, bool> predicate)
        {
            this.first = first;
            this.second = second;
            this.joinType = joinType;
            Columns = JoinColumns(first, second);
            Records = JoinRecords(first, second, predicate);
        }

        private IEnumerable<IResultRow> JoinRecords(IResultTable first, IResultTable second, Func<IResultRow, bool> predicate)
        {
            HashSet<IResultRow> usedRows = new HashSet<IResultRow>();
            var result = internalJoinRecords(usedRows, first, second, predicate);
            return result.Concat(buildOrphanRows(usedRows));
        }

        private IEnumerable<IResultRow> buildOrphanRows(HashSet<IResultRow> usedRows)
        {
            object[] firstNull = new object[first.Columns.Count()];
            object[] secondNull = new object[second.Columns.Count()];
            if (joinType == QualifiedJoinType.LeftOuter || joinType == QualifiedJoinType.FullOuter)
            {
                foreach (var row in first.Records)
                {
                    if (!usedRows.Contains(row))
                    {
                        yield return new Record(
                             row.ItemArray.Concat(secondNull).ToArray()
                             , this);
                    }
                }
            }
            if (joinType == QualifiedJoinType.RightOuter || joinType == QualifiedJoinType.FullOuter)
            {
                foreach (var row in second.Records)
                {
                    if (!usedRows.Contains(row))
                    {
                        yield return new Record(
                             firstNull.Concat(row.ItemArray).ToArray()
                             , this);
                    }
                }
            }
        }

        private IEnumerable<IResultRow> internalJoinRecords(HashSet<IResultRow> usedRows, IResultTable first, IResultTable second, Func<IResultRow, bool> predicate)
        { //TODO: this behaviour properly
            foreach (var row1 in first.Records)
            {
                foreach (var row2 in second.Records)
                {
                    var row = new Record(
                        row1.ItemArray.Concat(row2.ItemArray).ToArray()
                        , this);
                    if (predicate(row))
                    {
                        usedRows.Add(row1);
                        usedRows.Add(row2);
                        yield return row;
                    }

                }

            }
        }
        public override int IndexOfColumn(string[] name)
        {
            if (name.Length == 1)
            { return base.IndexOfColumn(name); }
            if (name.Length > 2) { throw new NotImplementedException(); }


            string tblName = name[0];
            string colName = name[1];
            //TODO: if the item1 (name) is null, i should check it anyway, the joins do not have names.
            //Maybe this should return -1 if not found, and i can check everything everytime. Maybe?
            if (first.TableName == tblName)
            {
                return first.IndexOfColumn(new string[] { colName });
            }
            if (second.TableName == tblName)
            {
                return first.Columns.Count() + second.IndexOfColumn(new string[] { colName });
            }
            throw new NotImplementedException("Error here? table not found");
        }
        protected virtual IEnumerable<ResultColumn> JoinColumns(IResultTable first, IResultTable second)
        {
            return first.Columns.Union(second.Columns).ToArray();
        }

    }
}
