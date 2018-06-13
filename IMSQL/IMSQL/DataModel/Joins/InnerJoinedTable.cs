using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSQL.DataModel.Results;

namespace IMSQL.DataModel.Joins
{
    public class InnerJoinedTable : RecordTable
    {
        CrossJoinedTable innerTable;
        public InnerJoinedTable(IResultTable first, IResultTable second, Func<IResultRow, bool> predicate)
        {
            innerTable = new CrossJoinedTable(first, second);
            this.Columns = innerTable.Columns;
            Records = FilterRecords(innerTable.Records, predicate);
        }
        public override int IndexOfColumn(string[] name)
        {
            return innerTable.IndexOfColumn(name);
        }
        private IEnumerable<IResultRow> FilterRecords(IEnumerable<IResultRow> records, Func<IResultRow, bool> predicate)
        {
            foreach (var row in records)
            {
                if (predicate(row))
                { yield return row; }
            }
        }
    }
}
