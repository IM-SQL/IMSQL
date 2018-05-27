using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class UniqueConstraint : Constraint
    {
        public UniqueConstraint(string constraintName, IEnumerable<Column> columns, bool isPrimaryKey)
            : this(constraintName, columns.First().Table, columns, isPrimaryKey)
        {}

        public UniqueConstraint(string constraintName, Table table, IEnumerable<Column> columns, bool isPrimaryKey)
            : base(constraintName, table)
        {
            Columns = columns;
            IsPrimaryKey = isPrimaryKey;
        }

        public IEnumerable<Column> Columns { get; }
        public bool IsPrimaryKey { get; }

        public override void OnInsert(Row row)
        {
            if (!Equals(Table, row.Table)) return;

            var cols = Columns.Select(col => row[col.ColumnName]).ToArray();
            if (Table.Rows.Any(each => cols.SequenceEqual(Columns.Select(col => each[col.ColumnName]))))
            {
                var msg = string.Format("Violation of UNIQUE KEY constraint '{0}'." +
                    " Cannot insert duplicate key in object '{1}'." +
                    " The duplicate key value is ({2}).", 
                    ConstraintName, Table.TableName, string.Join(", ", cols));
                throw new ConstraintException(msg);
            }
        }

        public override void OnDelete(Row row)
        {
            // TODO(Richo): ?
        }

        public override void OnUpdate(Row row, int columnIndex, object oldValue)
        {
            if (!Equals(Table, row.Table)) return;

            var cols = Columns.Select(col => row[col.ColumnName]).ToArray();
            if (Table.Rows.Except(new[] { row }).Any(each => cols.SequenceEqual(Columns.Select(col => each[col.ColumnName]))))
            {
                var msg = string.Format("Violation of UNIQUE KEY constraint '{0}'." +
                    " Cannot insert duplicate key in object '{1}'." +
                    " The duplicate key value is ({2}).",
                    ConstraintName, Table.TableName, string.Join(", ", cols));
                throw new ConstraintException(msg);
            }
        }
    }
}
