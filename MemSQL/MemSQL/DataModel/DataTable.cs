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
        private List<DataColumn> columns = new List<DataColumn>();

        public DataTable(Database database) : this(null, database) {}

        public DataTable(string tableName, Database database)
        {
            TableName = tableName;
            Database = database;
            Rows = new DataRowCollection(this);
        }

        // TODO(Richo): I would like to make TableName read-only.
        public string TableName { get; set; }

        public Database Database { get; }
        public DataRowCollection Rows { get; }
        public IEnumerable<DataColumn> Columns { get { return columns; } }

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
                    .OrderBy(column => columns.IndexOf(column))
                    .ToArray();
            }
            set
            {
                // TODO(Richo): Make unique name?
                var constraint = new UniqueConstraint("", value, true);
                Database.AddConstraint(constraint);
            }
        }

        public DataColumn GetColumn(int columnIndex)
        {
            return columns[columnIndex];
        }

        public DataColumn GetColumn(string columnName)
        {
            return columns.FirstOrDefault(col => Equals(columnName, col.ColumnName));
        }

        public int IndexOfColumn(string columnName)
        {
            return columns.FindIndex(col => Equals(columnName, col.ColumnName));
        }

        public bool ContainsColumn(string columnName)
        {
            return columns.Any(col => Equals(columnName, col.ColumnName));
        }

        public void AddColumns(IEnumerable<DataColumn> cols)
        {
            foreach (var col in cols)
            {
                AddColumn(col);
            }
        }

        public void AddColumn(DataColumn col)
        {
            col.Table = this;
            columns.Add(col);
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
