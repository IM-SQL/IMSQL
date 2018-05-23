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
        public Database() : this(new DataSet()) { }

        public Database(DataSet ds)
        {
            DataSet = ds;
            GlobalEnvironment = new Environment();
        }

        public DataSet DataSet { get; }
        public Environment GlobalEnvironment { get; }

        public DataTableCollection Tables { get { return DataSet.Tables; } }

        public int ExecuteNonQuery(string command, Dictionary<string,object> parameters) { throw new NotImplementedException(); }
        public DbDataReader ExecuteReader(string command, Dictionary<string, object> parameters) { throw new NotImplementedException(); }
        public T ExecuteScalar<T>(string command, Dictionary<string, object> parameters) { throw new NotImplementedException(); }
    }
}
