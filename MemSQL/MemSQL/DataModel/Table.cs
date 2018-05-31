using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class Table
    {
        private List<Row> rows = new List<Row>();
        private List<Column> columns = new List<Column>();

        public Table(Database database) : this(null, database) { }

        public Table(string tableName, Database database)
        {
            TableName = tableName;
            Database = database;
        }

        // TODO(Richo): I would like to make TableName read-only.
        public string TableName { get; set; }

        public Database Database { get; }
        public IEnumerable<Row> Rows { get { return rows; } }
        public IEnumerable<Column> Columns { get { return columns; } }

        public IEnumerable<Constraint> Constraints
        {
            get { return Database.Constraints.Where(c => Equals(this, c.Table)); }
        }

        public IEnumerable<UniqueConstraint> UniqueConstraints
        {
            get { return Constraints.OfType<UniqueConstraint>(); }
        }

        public Column[] PrimaryKey
        {
            get
            {
                return UniqueConstraints
                    .Where(constraint => constraint.IsPrimaryKey)
                    .SelectMany(constraint => constraint.Columns)
                    .Distinct()
                    .OrderBy(column => columns.IndexOf(column))
                    .ToArray();
            }
        }

        public Column GetColumn(int columnIndex)
        {
            return columns[columnIndex];
        }

        public Column GetColumn(string columnName)
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

        public void AddColumns(IEnumerable<Column> cols)
        {
            foreach (var col in cols)
            {
                AddColumn(col);
            }
        }

        public void AddColumn(Column col)
        {
            col.Table = this;
            columns.Add(col);
        }

        public Row GetRow(int index)
        {
            return rows[index];
        }

        public Row NewRow((string, object) first,  params (string,object)[] providedValues)
        {
            providedValues = Prepend(first, providedValues);
            return new Row(this, providedValues.ToDictionary(t=>t.Item1,t=>t.Item2));
        }

        public Row NewRow(Dictionary<string, object> providedValues)
        {
            return new Row(this, providedValues);
        }

        public Row NewRow(object first, params object[] items)
        { 
            return NewRow(Prepend(first,items));
        }

        // TODO(Richo): Maybe make it an extension method?
        private static T[] Prepend<T>(T first, T[] rest)
        {
            T[] values = new T[rest.Length + 1];
            values[0] = first;
            Array.Copy(rest, 0, values, 1, rest.Length);
            return values;
        }

        public Row NewRow(object[] items)
        {
            var providedColumns = new List<string>();
            for (int i = 0; i < Columns.Count(); i++)
            {
                if (!GetColumn(i).AutoIncrement && GetColumn(i).ComputedColumnSpecification==null)
                {
                    providedColumns.Add(GetColumn(i).ColumnName);
                }
            }
            if (items.Length != providedColumns.Count)
            {
                throw new ArgumentException("The values provided do not match the expected columns");
            }

            Dictionary<string, object> providedValues = new Dictionary<string, object>();
            for (int i = 0; i < providedColumns.Count; i++)
            {
                providedValues.Add(providedColumns[i], items[i]);
            }

            return NewRow(providedValues);
        }

        public void AddRow(params object[] items)
        {
            var row = NewRow(items);
            AddRow(row);
        }

        public void AddRow(Row row)
        {
            foreach (var constraint in Database.Constraints)
            {
                constraint.OnInsert(row);
            }
            rows.Add(row);
        }

        public void RemoveRow(Row row)
        {
            foreach (var constraint in Database.Constraints)
            {
                constraint.OnDelete(row);
            }
            rows.Remove(row);
        }

        public Row FindRow(object key)
        {
            return FindRow(new[] { key });
        }

        public Row FindRow(object[] keys)
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
