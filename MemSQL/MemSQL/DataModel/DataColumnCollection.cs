using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class DataColumnCollection : IEnumerable<DataColumn>
    {
        private DataTable table;
        private List<DataColumn> columns = new List<DataColumn>();

        public DataColumnCollection(DataTable table)
        {
            this.table = table;
        }

        public DataColumn this[int index] { get { return columns[index]; } }

        public DataColumn this[string name]
        {
            get { return columns.FirstOrDefault(col => Equals(name, col.ColumnName)); }
        }

        public int Count { get { return columns.Count; } }

        public int IndexOf(string name)
        {
            return columns.FindIndex(col => Equals(name, col.ColumnName));
        }

        public bool Contains(string name)
        {
            return columns.Any(col => Equals(name, col.ColumnName));
        }

        public void AddRange(IEnumerable<DataColumn> cols)
        {
            foreach (var col in cols)
            {
                Add(col);
            }
        }

        public void Add(DataColumn col)
        {
            col.Table = table;
            columns.Add(col);
        }

        public IEnumerator<DataColumn> GetEnumerator()
        {
            return columns.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
