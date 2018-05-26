using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public abstract class Constraint
    {
        public Constraint(string constraintName, DataTable table)
        {
            ConstraintName = constraintName;
            Table = table;
        }

        public string ConstraintName { get; set; }
        public DataTable Table { get; }

        public abstract void OnInsert(DataRow row);
        public abstract void OnDelete(DataRow row);
        public abstract void OnUpdate(DataRow row, int columnIndex, object oldValue);

        public override string ToString()
        {
            return string.Format("{0} ({1})", base.ToString(), ConstraintName);
        }

    }
}
