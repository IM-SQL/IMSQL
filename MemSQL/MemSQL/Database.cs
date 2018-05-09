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
        DataSet dataSet;
        public Database() {
            dataSet = new DataSet();
        }

        public int ExecuteNonQuery(string command, Dictionary<string,object> parameters) { throw new NotImplementedException(); }
        public DbDataReader ExecuteReader(string command, Dictionary<string, object> parameters) { throw new NotImplementedException(); }
        public T ExecuteScalar<T>(string command, Dictionary<string, object> parameters) { throw new NotImplementedException(); }
    }
}
