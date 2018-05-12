using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL.Test
{
    [TestClass]
    public class InsertionTests
    {
        [TestMethod]
        public void BasicInsertTest()
        {
            DataSet ds = new DataSet();
            DataTable table = ds.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            string query = "Insert into [TBL] values(3)";

            SQLInterpreter interpreter = new SQLInterpreter(ds);
            int affected = interpreter.Execute(query);

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count, "There should be one row on the table");
            Assert.AreEqual(3, table.Rows[0]["ID"], "The inserted value was not present on the table");
        }
    }
}
