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
    public class DeletionTests
    {
        [TestMethod]
        public void BasicDeleteTest()
        {
            DataSet ds = new DataSet();
            DataTable table = ds.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            
            var row = table.NewRow();
            row["ID"] = 3;
            table.Rows.Add(row);

            string query = "Delete from [TBL]";
            SQLInterpreter interpreter = new SQLInterpreter(ds);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(0, table.Rows.Count, "There should be no rows on the table");
            Assert.IsTrue(row.RowState == DataRowState.Detached, "The created row should have been detached because it is no longer in the table");
        }
        [TestMethod]
        public void BatchDeleteTest()
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
            string query = "Delete from [TBL]";
            SQLInterpreter interpreter = new SQLInterpreter(ds);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(100, affected, "There should be 100 row affected");
            Assert.AreEqual(0, table.Rows.Count, "There should be no rows on the table");
            }


    }
}
