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
        private List<DataRow> rows = new List<DataRow>();
        private List<DataColumn> columns = new List<DataColumn>();

        public DataTable(Database database) : this(null, database) {}

        public DataTable(string tableName, Database database)
        {
            TableName = tableName;
            Database = database;
        }

        // TODO(Richo): I would like to make TableName read-only.
        public string TableName { get; set; }

        public Database Database { get; }
        public IEnumerable<DataRow> Rows { get { return rows; } }
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

        public DataRow GetRow(int index)
        {
            return rows[index];
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

        public void AddRow(params object[] items)
        {
            var row = NewRow();
            row.ItemArray = items;
            AddRow(row);
        }

        public void AddRow(DataRow row)
        {
            foreach (var constraint in Database.Constraints)
            {
                constraint.OnInsert(row);
            }
            rows.Add(row);
        }

        public void RemoveRow(DataRow row)
        {
            foreach (var constraint in Database.Constraints)
            {
                constraint.OnDelete(row);
            }
            rows.Remove(row);
        }

        public DataRow FindRow(object key)
        {
            return FindRow(new[] { key });
        }

        public DataRow FindRow(object[] keys)
        {
            // TODO(Richo): Should we throw an exception if keys.Length doesn't match PrimaryKeys.Length?
            var pk = PrimaryKey;
            return rows.FirstOrDefault(row => keys.SequenceEqual(pk.Select(col => row[col.ColumnName])));
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
