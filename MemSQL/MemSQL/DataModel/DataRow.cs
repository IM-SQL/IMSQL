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
        private object[] currentValues;

        public DataRow(DataTable table)
        {
            Table = table;
            currentValues = new object[table.Columns.Count()];
        }

        public DataTable Table { get; }

        public object this[string name]
        {
            get { return currentValues[Table.IndexOfColumn(name)]; }
            set
            {
                var column = Table.GetColumn(name);
                int index = Table.IndexOfColumn(name);
                var oldValue = currentValues[index];
                if (value == null) { value = DBNull.Value; }
                try
                {
                    currentValues[index] = value == DBNull.Value ? value : Convert.ChangeType(value, column.DataType);
                    foreach (var constraint in Table.Database.Constraints)
                    {
                        constraint.OnUpdate(this, index, oldValue);
                    }
                }
                catch
                {
                    currentValues[index] = oldValue;
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
            get { return currentValues; }
            set { currentValues = value; }
        }

        public void Delete()
        {
            Table.RemoveRow(this);
        }
    }
}
