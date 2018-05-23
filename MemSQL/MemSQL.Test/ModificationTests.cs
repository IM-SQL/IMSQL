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
    public class ModificationTests
    {
        [TestMethod]
        public void BasicUpdateTest()
        {
            DataSet ds = new DataSet();
            DataTable table = ds.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));

            var row = table.NewRow();
            row["ID"] = 3;
            table.Rows.Add(row);

            string query = "Update [TBL] set ID=2";
            SQLInterpreter interpreter = new SQLInterpreter(ds);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(2, table.Rows[0]["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void BatchUpdateTest()
        {
            DataSet ds = new DataSet();
            DataTable table = ds.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            for (int i = 0; i < 100; i++)
            {
                var row = table.NewRow();
                row["ID"] = i;
                table.Rows.Add(row);
            }
            string query = "Update [TBL] set ID=2";
            SQLInterpreter interpreter = new SQLInterpreter(ds);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(100, affected, "There should be 100 rows affected");
            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(2, table.Rows[i]["ID"], "The updated value was not present on All the rows of the Table");
            }
            {

            }
        }
    }
}
