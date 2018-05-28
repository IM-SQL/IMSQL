﻿using MemSQL.DataModel;
using MemSQL.DataModel.Fields;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class Row
    {
        private Field[] values;

        public Row(Table table)
        {
            Table = table;
            values = table.Columns
                .Select(col => col.NewField())
                .ToArray();
        }

        public Table Table { get; }

        public object this[string name]
        {
            get { return values[Table.IndexOfColumn(name)].Value; }
            set
            {
                int index = Table.IndexOfColumn(name);
                var column = Table.GetColumn(index);
                var field = values[index];
                var oldValue = field.Value;
                if (value == null) { value = DBNull.Value; }
                try
                {
                    field.Value = value == DBNull.Value ? value : Convert.ChangeType(value, column.DataType);
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

        public object[] ItemArray
        {
            get { return values; }
            set
            {
                //TODO: validation of the length?
                for (int i = 0; i < value.Length; i++)
                {
                    values[i].Value = value[i];

                }

            }
        }

        public void Delete()
        {
            Table.RemoveRow(this);
        }
    }
}
