using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemSQL.DataModel.Results;

namespace MemSQL.DataModel.Joins
{
    public class InnerJoinTable : RecordSet
    {
        public InnerJoinTable((string, RecordTable) first, (string, RecordTable) second, Func<Record, bool> predicate)
            : base()
        {
            Columns = JoinColumns(first, second);
            Records = JoinRecords(first.Item2, second.Item2, predicate).ToArray();
        }


        private IEnumerable<RecordColumn> JoinColumns((string, RecordTable) first, (string, RecordTable) second)
        {

            return first.Item2.Columns
                .Select(col => { return new RecordColumn(first.Item1 + "." + col.ColumnName, col.DataType); })
                .Union(
                    second.Item2.Columns.Select(col =>
                    {
                        return new RecordColumn(second.Item1 + "." + col.ColumnName, col.DataType);
                    })).ToArray();
        }

        private IEnumerable<Record> JoinRecords(RecordTable first, RecordTable second, Func<Record, bool> predicate)
        {
            //TODO: this behaviour properly
            foreach (var row1 in first.Records)
            {
                foreach (var row2 in second.Records)
                {
                    var row = new RowRecord(
                        row1.ItemArray.Concat(row2.ItemArray).ToArray()
                        , this);
                    //if (predicate(row))

                    yield return row;
                }

            }

        }
    }
}
