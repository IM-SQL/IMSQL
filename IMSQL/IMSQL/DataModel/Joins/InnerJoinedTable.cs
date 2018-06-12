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
        public InnerJoinedTable(IResultTable first, IResultTable second, Func<IResultRow, bool> predicate)
        {
            CrossJoinedTable innerTable = new CrossJoinedTable(first, second);
            this.Columns = innerTable.Columns;
            Records = FilterRecords(innerTable.Records, predicate);
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
