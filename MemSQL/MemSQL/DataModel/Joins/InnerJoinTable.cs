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
        private readonly  RecordTable first;
        private readonly  RecordTable second;

        public InnerJoinTable( RecordTable first,  RecordTable second, Func<Record, bool> predicate)
            : base()
        {
            Columns = JoinColumns(first, second);
            Records = JoinRecords(first, second, predicate).ToArray();
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

        private IEnumerable<RecordColumn> JoinColumns( RecordTable first,  RecordTable second)
        {
            return first.Columns.Union(second.Columns).ToArray();
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
