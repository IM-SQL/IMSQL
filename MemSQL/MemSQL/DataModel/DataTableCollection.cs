using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class DataTableCollection
    {
        private Database database;
        private Dictionary<string, DataTable> tables = new Dictionary<string, DataTable>();

        public DataTableCollection(Database database)
        {
            this.database = database;
        }
                
        public DataTable this[string name]
        {
            get
            {
                if (tables.TryGetValue(name, out DataTable table)) return table;
                return null;
            }
        }

        public DataTable Add(string tableName)
        {
            var table = new DataTable(tableName, database);
            Add(table);
            return table;
        }

        public void Add(DataTable table)
        {
            tables.Add(table.TableName, table);
        }

        public void Remove(DataTable table)
        {
            tables.Remove(table.TableName);
        }

        public bool Contains(string tableName)
        {
            return tables.ContainsKey(tableName);
        }
    }
}
