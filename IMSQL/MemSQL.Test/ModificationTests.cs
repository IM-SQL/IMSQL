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
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));

            var row = table.NewRow(3);
            table.AddRow(row);

            string query = "Update [TBL] set ID=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(2, table.GetRow(0)["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void BatchUpdateTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 100; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Update [TBL] set ID=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(100, affected, "There should be 100 rows affected");
            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(2, table.GetRow(i)["ID"], "The updated value was not present on All the rows of the Table");
            }
        }

        [TestMethod]
        public void AddAssignmentUpdateTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));

            var row = table.NewRow(3);
            table.AddRow(row);

            string query = "Update [TBL] set ID +=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(5, table.GetRow(0)["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void AddAssignmentStringUpdateTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(string)));

            var row = table.NewRow("hola");
            table.AddRow(row);

            string query = "Update [TBL] set ID +='-chau'";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual("hola-chau", table.GetRow(0)["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void AddAssignmentMixedTypesUpdateTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(string)));

            var row = table.NewRow("hola");
            table.AddRow(row);

            string query = "Update [TBL] set ID +=3";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual("hola3", table.GetRow(0)["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void SubAssignmentUpdateTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));

            var row = table.NewRow(3);
            table.AddRow(row);

            string query = "Update [TBL] set ID -=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.GetRow(0)["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void MulAssignmentUpdateTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));

            var row = table.NewRow(3);
            table.AddRow(row);

            string query = "Update [TBL] set ID *=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(6, table.GetRow(0)["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void DivAssignmentUpdateTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));

            var row = table.NewRow(10);
            table.AddRow(row);

            string query = "Update [TBL] set ID /=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(5, table.GetRow(0)["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void ModAssignmentUpdateTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));

            var row = table.NewRow(10);
            table.AddRow(row);

            string query = "Update [TBL] set ID %=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(0, table.GetRow(0)["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void AndAssignmentUpdateTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));

            var row = table.NewRow(5);
            table.AddRow(row);

            string query = "Update [TBL] set ID &=3";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(5 & 3, table.GetRow(0)["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void OrAssignmentUpdateTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));

            var row = table.NewRow(4);
            table.AddRow(row);

            string query = "Update [TBL] set ID |=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(4 | 2, table.GetRow(0)["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void XorAssignmentUpdateTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));

            var row = table.NewRow(7);
            table.AddRow(row);

            string query = "Update [TBL] set ID ^=5";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(7 ^ 5, table.GetRow(0)["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void TopUpdateTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 200; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Update TOP(50)  [TBL] set ID=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(50, affected, "There should be 50 row affected");

            int count = 0;
            for (int i = 0; i < 200; i++)
            {
                if (table.GetRow(i)["ID"].Equals(2))
                    count++;
            }
            Assert.AreEqual(50, affected, "There was suposed to be 50 rows with the updated ID");
        }

        [TestMethod]
        public void TopPercentUpdateTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 200; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Update TOP(50) PERCENT [TBL] set ID=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(100, affected, "There should be 100 row affected");
            int count = 0;
            for (int i = 0; i < 200; i++)
            {
                if (table.GetRow(i)["ID"].Equals(2))
                    count++;
            }
            Assert.AreEqual(100, affected, "There was suposed to be 100 rows with the updated ID");
        }

        [TestMethod]
        public void UpdateWhereEquals()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 100; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Update [TBL] set [ID]=5 where [ID] = 1";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be 1 row affected");
            int count = 0;
            for (int i = 0; i < 100; i++)
            {
                if (table.GetRow(i)["ID"].Equals(5))
                    count++;
            }
            Assert.AreEqual(2, count, "There was suposed to be 2 rows with the updated ID");
        }
        [TestMethod]
        public void UpdateWithoutOutputShouldNotReturnValues()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("A", typeof(int)));
            table.AddColumn(new Column("B", typeof(string)));
            var r = table.NewRow(3, "asd");
            table.AddRow(r);
            string query = "Update [TBL] set A=2, B='qwe'";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(null, result.Values, "No result should have been returned");
        }
        [TestMethod]
        public void UpdateWithOutput()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("A", typeof(int)));
            table.AddColumn(new Column("B", typeof(string)));
            var r = table.NewRow(3, "asd");
            table.AddRow(r);
            string query = "Update [TBL] set A=2, B='qwe' output updated.*";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreNotEqual(null, result.Values, "One result should have been returned");
            var resultSet = result.Values;
            Assert.AreEqual(2, resultSet.Columns.Count(), "The result should have two columns");
            Assert.AreEqual("A", resultSet.Columns.ElementAt(0).ColumnName, "Failed to find the expected column");
            Assert.AreEqual("B", resultSet.Columns.ElementAt(1).ColumnName, "Failed to find the expected column");

            Assert.AreEqual(1, resultSet.Records.Count(), "There should be one row");
            var row = resultSet.Records.ElementAt(0);

            Assert.AreEqual(2, row["A"], "The expected result was not present in the row");
            Assert.AreEqual("qwe", row["B"], "The expected result was not present in the row");

        }
        [TestMethod]
        public void UpdateWithSelectiveOutput()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("A", typeof(int)));
            table.AddColumn(new Column("B", typeof(string)));
            var r = table.NewRow(3, "asd");
            table.AddRow(r);
            string query = "Update [TBL] set A=2, B='qwe' output updated.A";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreNotEqual(null, result.Values, "One result should have been returned");
            var resultSet = result.Values;
            Assert.AreEqual(1, resultSet.Columns.Count(), "The result should have two columns");
            Assert.AreEqual("A", resultSet.Columns.ElementAt(0).ColumnName, "Failed to find the expected column");

            Assert.AreEqual(1, resultSet.Records.Count(), "There should be one row");
            var row = resultSet.Records.ElementAt(0);

            Assert.AreEqual(2, row["A"], "The expected result was not present in the row");

        }
    }
}
