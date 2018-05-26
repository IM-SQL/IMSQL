using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class DataRowCollection : IEnumerable<DataRow>
    {
        private DataTable table;
        private List<DataRow> rows = new List<DataRow>();

        public DataRowCollection(DataTable table)
        {
            this.table = table;
        }

        public DataRow this[int index] { get { return rows[index]; } }

        public int Count { get { return rows.Count; } }

        public void Add(DataRow row)
        {
            foreach (var constraint in table.Database.Constraints)
            {
                constraint.OnInsert(row);
            }
            rows.Add(row);
        }

        public void Add(params object[] items)
        {
            var row = table.NewRow();
            row.ItemArray = items;
            Add(row);
        }

        public void Remove(DataRow row)
        {
            foreach (var constraint in table.Database.Constraints)
            {
                constraint.OnDelete(row);
            }
            rows.Remove(row);
        }

        public DataRow Find(object key)
        {
            return Find(new[] { key });
        }

        public DataRow Find(object[] keys)
        {
            // TODO(Richo): Should we throw an exception if keys.Length doesn't match PrimaryKeys.Length?
            var pk = table.PrimaryKey;
            return rows.FirstOrDefault(row => keys.SequenceEqual(pk.Select(col => row[col.ColumnName])));
        }

        public IEnumerator<DataRow> GetEnumerator()
        {
            return rows.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
