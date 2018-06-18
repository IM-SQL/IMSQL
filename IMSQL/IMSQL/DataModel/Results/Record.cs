using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSQL.DataModel.Joins;

namespace IMSQL.DataModel.Results
{
    public class Record : IResultRow
    {
        private object[] values;
        private RecordTable set;

        public Record(IResultRow row, RecordTable recordSet)
        {
            set = recordSet;
            values = new object[set.Columns.Count()];
            int index = 0;
            foreach (var col in set.Selectors)
            {
                values[index++] = col.GetValueFrom(row);
            }
        }

        public Record(object[] v, RecordTable recordSet)
        {
            set = recordSet;
            values = v;
        }

        RecordTable Set { get { return set; } }

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

        public IResultRow Wrap(RecordTable recordSet)
        {
            return new Record(ItemArray, recordSet);
        }
    }
}
