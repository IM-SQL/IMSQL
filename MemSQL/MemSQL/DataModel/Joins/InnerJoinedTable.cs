using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemSQL.DataModel.Results;

namespace MemSQL.DataModel.Joins
{
    public class InnerJoinedTable : RecordSet
    {
        public InnerJoinedTable(RecordTable first, RecordTable second, Func<Record, bool> predicate)
        {
            CrossJoinedTable innerTable = new CrossJoinedTable(first, second);
            this.Columns = innerTable.Columns;
            Records = FilterRecords(innerTable.Records, predicate);
        }

        private IEnumerable<Record> FilterRecords(IEnumerable<Record> records, Func<Record, bool> predicate)
        {
            foreach (var row in records)
            {
                if (predicate(row))
                { yield return row; }
            }
        }
    }
}
