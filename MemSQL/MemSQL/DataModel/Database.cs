using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class Database
    {
        private Dictionary<string, DataTable> tables = new Dictionary<string, DataTable>();
        private List<Constraint> constraints = new List<Constraint>();

        public Database()
        {
            GlobalEnvironment = new Environment();
        }

        public Environment GlobalEnvironment { get; }
        public IEnumerable<DataTable> Tables { get { return tables.Values; } }
        public IEnumerable<Constraint> Constraints { get { return constraints; } }

        public DataTable GetTable(string tableName)
        {
            if (tables.TryGetValue(tableName, out DataTable table)) return table;
            return null;
        }
        
        public DataTable AddTable(string tableName)
        {
            var table = new DataTable(tableName, this);
            AddTable(table);
            return table;
        }

        public void AddTable(DataTable table)
        {
            tables.Add(table.TableName, table);
        }

        public void RemoveTable(DataTable table)
        {
            tables.Remove(table.TableName);
        }

        public bool ContainsTable(string tableName)
        {
            return tables.ContainsKey(tableName);
        }

        public Constraint GetConstraint(string constraintName)
        {
            return constraints.FirstOrDefault(col => Equals(constraintName, col.ConstraintName));
        }

        public bool ContainsConstraint(string constraintName)
        {
            return constraints.Any(each => Equals(constraintName, each.ConstraintName));
        }

        public void AddConstraint(Constraint constraint)
        {
            constraints.Add(constraint);
        }

        public int ExecuteNonQuery(string command, Dictionary<string,object> parameters) { throw new NotImplementedException(); }
        public DbDataReader ExecuteReader(string command, Dictionary<string, object> parameters) { throw new NotImplementedException(); }
        public T ExecuteScalar<T>(string command, Dictionary<string, object> parameters) { throw new NotImplementedException(); }
    }
}
