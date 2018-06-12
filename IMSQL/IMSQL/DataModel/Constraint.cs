using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public abstract class Constraint
    {
        public Constraint(string constraintName, Table table)
        {
            ConstraintName = constraintName;
            Table = table;
        }

        public string ConstraintName { get; set; }
        public Table Table { get; }

        public abstract void OnInsert(Row row);
        public abstract void OnDelete(Row row);
        public abstract void OnUpdate(Row row, int columnIndex, object oldValue);

        public override string ToString()
        {
            return string.Format("{0} ({1})", base.ToString(), ConstraintName);
        }
    }
}
