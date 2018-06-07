using MemSQL.DataModel;
using MemSQL.DataModel.Fields;
using MemSQL.DataModel.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class Row:Record
    {
        private Field[] values;

        public Row(Table table, Dictionary<string, object> providedValues)
        {
            Table = table;
            values = table.Columns
                .Select(col => providedValues.ContainsKey(col.ColumnName) ?
                    col.NewField(providedValues[col.ColumnName], this) : 
                    col.NewField(this))
                .ToArray();
        }

        public Table Table { get; }

        public object this[params string[] name]
        {
            get
            {
                int index = Table.IndexOfColumn(name);
                if (index == -1)
                {
                    throw new InvalidOperationException("Invalid object name " + string.Join(".", name));
                }
                return values[index].Value;
            }
            set
            {
                int index = Table.IndexOfColumn(name);
                if (index == -1)
                {
                    throw new InvalidOperationException("Invalid object name " + string.Join(".", name));
                }
                var column = Table.GetColumn(index);
                var field = values[index];
                var oldValue = field.Value;
                try
                {
                    field.Value = value;
                    foreach (var constraint in Table.Database.Constraints)
                    {
                        constraint.OnUpdate(this, index, oldValue);
                    }
                }
                catch
                {
                    field.Value = oldValue;
                    throw;
                }
            }
        }

        public DataRowState RowState
        {
            // TODO(Richo): Do we need this?
            get { return DataRowState.Detached; }
        }

        public object[] ItemArray => values.Select(v=>v.Value).ToArray();

        public void Delete()
        {
            Table.RemoveRow(this);
        }

        public Record Wrap(RecordSet recordSet)
        {
            return new RowRecord(ItemArray, recordSet);
        }
    }
}
