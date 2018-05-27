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
        private Dictionary<string, Table> tables = new Dictionary<string, Table>();
        private List<Constraint> constraints = new List<Constraint>();

        public Database()
        {
            GlobalEnvironment = new Environment();
        }

        public Environment GlobalEnvironment { get; }
        public IEnumerable<Table> Tables { get { return tables.Values; } }
        public IEnumerable<Constraint> Constraints { get { return constraints; } }

        public Table GetTable(string tableName)
        {
            if (tables.TryGetValue(tableName, out Table table)) return table;
            return null;
        }
        
        public Table AddTable(string tableName)
        {
            var table = new Table(tableName, this);
            AddTable(table);
            return table;
        }

        public void AddTable(Table table)
        {
            tables.Add(table.TableName, table);
        }

        public void RemoveTable(Table table)
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
