﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL.DataModel.Views
{
    public class Record
    {
        private object[] values;
        private RecordSet set;

        public Record(Row row, RecordSet recordSet)
        {
            set = recordSet;
            values = new object[set.Columns.Count()];
            int index = 0;
            foreach (var col in set.selectors)
            {
                values[index++] = col.Item2(row);
            }
        }

        RecordSet Set { get { return set; } }

        public object this[string name]
        {
            get { return values[Set.IndexOfColumn(name)]; }
        }

        public object[] ItemArray { get { return values; } }
    }
}
