using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class DataTable
    {
        private long? identity = null;

        public DataTable(Database database) : this(null, database) {}

        public DataTable(string tableName, Database database)
        {
            TableName = tableName;
            Database = database;
            Rows = new DataRowCollection(this);
            Columns = new DataColumnCollection(this);
        }

        // TODO(Richo): I would like to make TableName read-only.
        public string TableName { get; set; }

        public Database Database { get; }
        public DataRowCollection Rows { get; }
        public DataColumnCollection Columns { get; }

        public DataColumn[] PrimaryKey
        {
            get
            {
                return Database.Constraints
                    .OfType<UniqueConstraint>()
                    .Where(constraint => Equals(this, constraint.Table))
                    .Where(constraint => constraint.IsPrimaryKey)
                    .SelectMany(constraint => constraint.Columns)
                    .Distinct()
                    .OrderBy(column => Columns.IndexOf(column.ColumnName))
                    .ToArray();
            }
            set
            {
                // TODO(Richo): Make unique name?
                var constraint = new UniqueConstraint("", value, true);
                Database.AddConstraint(constraint);
            }
        }

        public DataRow NewRow()
        {
            var row = new DataRow(this);
            foreach (var col in Columns)
            {
                if (col.AutoIncrement)
                {
                    identity = identity.HasValue ? identity + col.AutoIncrementStep : col.AutoIncrementSeed;
                    row[col.ColumnName] = identity;
                }
                else if (col.DefaultValue != null)
                {
                    row[col.ColumnName] = col.DefaultValue;
                }
                else if (col.AllowDBNull)
                {
                    row[col.ColumnName] = DBNull.Value;
                }
            }
            return row;
        }

        public void Add(DataRow row)
        {
            Rows.Add(row);
        }

        public void AcceptChanges()
        {
            // TODO(Richo): Do we need this?
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", base.ToString(), TableName);
        }
    }
}
