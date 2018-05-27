using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class DataRow
    {
        private object[] values;

        public DataRow(DataTable table)
        {
            Table = table;
            values = new object[table.Columns.Count()];
        }

        public DataTable Table { get; }

        public object this[string name]
        {
            get { return values[Table.IndexOfColumn(name)]; }
            set
            {
                int index = Table.IndexOfColumn(name);
                var column = Table.GetColumn(index);
                var oldValue = values[index];
                if (value == null) { value = DBNull.Value; }
                try
                {
                    values[index] = value == DBNull.Value ? value : Convert.ChangeType(value, column.DataType);
                    foreach (var constraint in Table.Database.Constraints)
                    {
                        constraint.OnUpdate(this, index, oldValue);
                    }
                }
                catch
                {
                    values[index] = oldValue;
                    throw;
                }
            }
        }

        public DataRowState RowState
        {
            // TODO(Richo): Do we need this?
            get { return DataRowState.Detached; }
        }

        public object[] ItemArray
        {
            get { return values; }
            set { values = value; }
        }

        public void Delete()
        {
            Table.RemoveRow(this);
        }
    }
}
