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
            var db = new Database();
            DataTable table = db.AddTable("TBL");
            table.AddColumn(new DataColumn("ID", typeof(int)));
            string query = "Insert into [TBL] values(3)";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count(), "There should be one row on the table");
            Assert.AreEqual(3, table.GetRow(0)["ID"], "The inserted value was not present on the table");
        }

        [TestMethod]
        public void MultivaluedInsertTest()
        {
            var db = new Database();
            DataTable table = db.AddTable("TBL");
            table.AddColumn(new DataColumn("A", typeof(int)));
            table.AddColumn(new DataColumn("B", typeof(string)));
            string query = "Insert into [TBL] values(3,'asd')";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count(), "There should be one row on the table");
            Assert.AreEqual(3, table.GetRow(0)["A"], "The inserted value was not present on the table");
            Assert.AreEqual("asd", table.GetRow(0)["B"], "The inserted value was not present on the table");
        }

        [TestMethod]
        public void InsertIdentityShouldFail()
        {
            var db = new Database();
            DataTable table = db.AddTable("TBL");
            table.AddColumn(new DataColumn("A", typeof(int)));

            table.GetColumn("A").AutoIncrement = true;
            table.GetColumn("A").AutoIncrementSeed = 1;
            table.GetColumn("A").AutoIncrementStep = 1;
            string query = "Insert into [TBL](A) values(3)";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                /*
                * INFO(Tera): This should fail. SQL Server 2014 throws the following error: 
                * Msg 544, Level 16, State 1, Line 4
                * Cannot insert explicit value for identity column in table 'TBL' when IDENTITY_INSERT is set to OFF.
                */
                interpreter.Execute(query);
            });
        }

        [TestMethod]
        public void DefaultValueInsertTest()
        {
            var db = new Database();
            DataTable table = db.AddTable("TBL");
            table.AddColumn(new DataColumn("A", typeof(int)));
            table.AddColumn(new DataColumn("B", typeof(int)));
            table.GetColumn("B").DefaultValue = 5;
            string query = "Insert into [TBL](A) values(3)";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count(), "There should be one row on the table");
            Assert.AreEqual(3, table.GetRow(0)["A"], "The inserted value was not present on the table");
            Assert.AreEqual(5, table.GetRow(0)["B"], "The Default value was not present on the table");
        }

        [TestMethod]
        public void DBNULLInsertTest()
        {
            var db = new Database();
            DataTable table = db.AddTable("TBL");
            table.AddColumn(new DataColumn("A", typeof(int)));
            table.GetColumn(0).AllowDBNull = true;
            string query = "Insert into [TBL] values(NULL)";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count(), "There should be one row on the table");
            Assert.AreEqual(DBNull.Value, table.GetRow(0)["A"], "The inserted value was not present on the table");
        }

        [TestMethod]
        public void UnorderedValuesTest()
        {
            var db = new Database();
            DataTable table = db.AddTable("TBL");
            table.AddColumn(new DataColumn("A", typeof(int)));
            table.AddColumn(new DataColumn("B", typeof(int)));
            string query = "Insert into [TBL](B,A) values(2,1)";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count(), "There should be one row on the table");
            Assert.AreEqual(1, table.GetRow(0)["A"], "The inserted value was not present on the table");
            Assert.AreEqual(2, table.GetRow(0)["B"], "The inserted value was not present on the table");
        }

        [TestMethod]
        public void SelectedValuesTest()
        {
            var db = new Database();
            DataTable table = db.AddTable("TBL");
            table.AddColumn(new DataColumn("A", typeof(int)));
            table.AddColumn(new DataColumn("B", typeof(int)));
            table.AddColumn(new DataColumn("C", typeof(int)));
            table.GetColumn("C").AllowDBNull = true;
            string query = "Insert into [TBL](B,A) values(2,1)";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count(), "There should be one row on the table");
            Assert.AreEqual(1, table.GetRow(0)["A"], "The inserted value was not present on the table");
            Assert.AreEqual(2, table.GetRow(0)["B"], "The inserted value was not present on the table");
            Assert.AreEqual(DBNull.Value, table.GetRow(0)["C"], "The default value was not present on the table");
        }

        [TestMethod]
        public void BatchInsertTest()
        {
            List<Tuple<int, int>> testData = new List<Tuple<int, int>>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 5; j < 10; j++)
                {
                    testData.Add(new Tuple<int, int>(i, j));
                }
            }
            Func<Tuple<int, int>, string> printTuple = (t) => string.Format("( {0} , {1} )", t.Item1, t.Item2);

            var db = new Database();
            DataTable table = db.AddTable("TBL");
            table.AddColumn(new DataColumn("A", typeof(int)));
            table.AddColumn(new DataColumn("B", typeof(int)));

            string query =
                string.Format(
                "Insert into [TBL] values {0}", string.Join(", ", testData.Select(t => printTuple(t))));

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(testData.Count, affected, "The amount of rows affected is wrong");
            Assert.AreEqual(testData.Count, table.Rows.Count(), "All the test data should have been inserted");
            for (int i = 0; i < testData.Count; i++)
            {
                Assert.AreEqual(testData[i].Item1, table.GetRow(i)["A"], "The inserted value was not present on the table");
                Assert.AreEqual(testData[i].Item2, table.GetRow(i)["B"], "The inserted value was not present on the table");
            }
        }

        [TestMethod]
        public void InsufficientParametersWithoutFieldNameShouldFail()
        {
            var db = new Database();
            DataTable table = db.AddTable("TBL");
            table.AddColumn(new DataColumn("A", typeof(int)));
            table.AddColumn(new DataColumn("B", typeof(int)));
            string query = "Insert into [TBL] values(3)";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                /*
                 * INFO(Tera): This should fail. SQL Server 2014 throws the following error: 
                 * Msg 213, Level 16, State 1, Line 4
                 * Column name or number of supplied values does not match table definition.
                 */
                interpreter.Execute(query);
            });
        }

        [TestMethod]
        public void InsufficientParametersWithoutFieldNameEvenWithDefaultValuesShouldFail()
        {
            var db = new Database();
            DataTable table = db.AddTable("TBL");
            table.AddColumn(new DataColumn("A", typeof(int)));
            table.AddColumn(new DataColumn("B", typeof(int)));
            table.GetColumn("A").DefaultValue = 5;
            string query = "Insert into [TBL] values(3)";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                /*
                 * INFO(Tera): This should fail. SQL Server 2014 throws the following error: 
                 * Msg 213, Level 16, State 1, Line 4
                 * Column name or number of supplied values does not match table definition.
                 */
                interpreter.Execute(query);
            });
        }

        [TestMethod]
        public void InsufficientParametersWithoutNameShouldNotConsiderIdentityColumns()
        {
            var db = new Database();
            DataTable table = db.AddTable("TBL");
            table.AddColumn(new DataColumn("A", typeof(int)));
            table.AddColumn(new DataColumn("B", typeof(string)));
            table.GetColumn("A").AutoIncrement = true;
            table.GetColumn("A").AutoIncrementSeed = 1;
            table.GetColumn("A").AutoIncrementStep = 1;

            string query = "Insert into [TBL] values('asd')";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query);
            Assert.AreEqual(1, result.RowsAffected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count(), "There should be one row on the table");
            Assert.AreEqual(1, table.GetRow(0)["A"], "The inserted value was not present on the table");
            Assert.AreEqual("asd", table.GetRow(0)["B"], "The inserted value was not present on the table");
        }
    }
}
