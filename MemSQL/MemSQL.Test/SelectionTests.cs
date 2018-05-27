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
    public class SelectionTests
    {
        [TestMethod]
        public void BasicSelectTest()
        {
            var db = new Database();
            DataTable table = db.AddTable("TBL");
            table.AddColumn(new DataColumn("ID", typeof(int)));

            var row = table.NewRow();
            row["ID"] = 3;
            table.AddRow(row);

            string query = "Select * from [TBL]";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(3, table.GetRow(0)["ID"], "The selected value was not present on the Table");
        }
    }
}
