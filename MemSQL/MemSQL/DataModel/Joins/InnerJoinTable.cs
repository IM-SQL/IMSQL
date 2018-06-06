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
        private readonly (string, RecordTable) first;
        private readonly (string, RecordTable) second;

        public InnerJoinTable((string, RecordTable) first, (string, RecordTable) second, Func<Record, bool> predicate)
            : base()
        {
            Columns = JoinColumns(first, second);
            Records = JoinRecords(first.Item2, second.Item2, predicate).ToArray();
            this.first = first;
            this.second = second;
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
            if (first.Item1 == tblName)
            {
                return first.Item2.IndexOfColumn(new string[] { colName });
            }
            if (second.Item1 == tblName)
            {
                return first.Item2.Columns.Count() + second.Item2.IndexOfColumn(new string[] { colName });
            }
            throw new NotImplementedException("Error here? table not found");
        }

        private IEnumerable<RecordColumn> JoinColumns((string, RecordTable) first, (string, RecordTable) second)
        {
            return first.Item2.Columns.Union(second.Item2.Columns).ToArray();
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
                    if (predicate(row))
                    {
                        yield return row;
                    }
                }

            }

        }
    }
}
