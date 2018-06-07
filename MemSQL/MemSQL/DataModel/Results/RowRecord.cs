using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemSQL.DataModel.Joins;

namespace MemSQL.DataModel.Results
{
    public class RowRecord : Record
    {
        private object[] values;
        private RecordSet set;

        public RowRecord(Record row, RecordSet recordSet)
        {
            set = recordSet;
            values = new object[set.Columns.Count()];
            int index = 0;
            foreach (var col in set.Selectors)
            {
                values[index++] = col.Item2(row);
            }
        }

        public RowRecord(object[] v, RecordSet recordSet)
        {
            set = recordSet;
            values = v;
        }

        RecordSet Set { get { return set; } }

        public object this[params string[] name]
        {
            get
            {
                int index = Set.IndexOfColumn(name);
                if (index == -1)
                {
                    throw new InvalidOperationException("Invalid object name " + string.Join(".", name));
                }
                return values[index];
            }
        }

        public object[] ItemArray { get { return values; } }

        public Record Wrap(RecordSet recordSet)
        {
            return new RowRecord(ItemArray, recordSet);
        }
    }
}
