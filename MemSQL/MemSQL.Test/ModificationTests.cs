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
            DataTable table = db.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));

            var row = table.NewRow();
            row["ID"] = 3;
            table.Rows.Add(row);

            string query = "Update [TBL] set ID=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(2, table.Rows[0]["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void BatchUpdateTest()
        {
            var db = new Database();
            DataTable table = db.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            for (int i = 0; i < 100; i++)
            {
                var row = table.NewRow();
                row["ID"] = i;
                table.Rows.Add(row);
            }
            string query = "Update [TBL] set ID=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(100, affected, "There should be 100 rows affected");
            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(2, table.Rows[i]["ID"], "The updated value was not present on All the rows of the Table");
            }
        }

        [TestMethod]
        public void AddAssignmentUpdateTest()
        {
            var db = new Database();
            DataTable table = db.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));

            var row = table.NewRow();
            row["ID"] = 3;
            table.Rows.Add(row);

            string query = "Update [TBL] set ID +=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(5, table.Rows[0]["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void AddAssignmentStringUpdateTest()
        {
            var db = new Database();
            DataTable table = db.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(string)));

            var row = table.NewRow();
            row["ID"] = "hola";
            table.Rows.Add(row);

            string query = "Update [TBL] set ID +='-chau'";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual("hola-chau", table.Rows[0]["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void AddAssignmentMixedTypesUpdateTest()
        {
            var db = new Database();
            DataTable table = db.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(string)));

            var row = table.NewRow();
            row["ID"] = "hola";
            table.Rows.Add(row);

            string query = "Update [TBL] set ID +=3";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual("hola3", table.Rows[0]["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void SubAssignmentUpdateTest()
        {
            var db = new Database();
            DataTable table = db.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));

            var row = table.NewRow();
            row["ID"] = 3;
            table.Rows.Add(row);

            string query = "Update [TBL] set ID -=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows[0]["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void MulAssignmentUpdateTest()
        {
            var db = new Database();
            DataTable table = db.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));

            var row = table.NewRow();
            row["ID"] = 3;
            table.Rows.Add(row);

            string query = "Update [TBL] set ID *=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(6, table.Rows[0]["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void DivAssignmentUpdateTest()
        {
            var db = new Database();
            DataTable table = db.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));

            var row = table.NewRow();
            row["ID"] = 10;
            table.Rows.Add(row);

            string query = "Update [TBL] set ID /=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(5, table.Rows[0]["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void ModAssignmentUpdateTest()
        {
            var db = new Database();
            DataTable table = db.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));

            var row = table.NewRow();
            row["ID"] = 10;
            table.Rows.Add(row);

            string query = "Update [TBL] set ID %=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(0, table.Rows[0]["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void AndAssignmentUpdateTest()
        {
            var db = new Database();
            DataTable table = db.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));

            var row = table.NewRow();
            row["ID"] = 5;
            table.Rows.Add(row);

            string query = "Update [TBL] set ID &=3";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(5 & 3, table.Rows[0]["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void OrAssignmentUpdateTest()
        {
            var db = new Database();
            DataTable table = db.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));

            var row = table.NewRow();
            row["ID"] = 4;
            table.Rows.Add(row);

            string query = "Update [TBL] set ID |=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(4 | 2, table.Rows[0]["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void XorAssignmentUpdateTest()
        {
            var db = new Database();
            DataTable table = db.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));

            var row = table.NewRow();
            row["ID"] = 7;
            table.Rows.Add(row);

            string query = "Update [TBL] set ID ^=5";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(7 ^ 5, table.Rows[0]["ID"], "The updated value was not present on the Table");
        }

        [TestMethod]
        public void TopUpdateTest()
        {
            var db = new Database();
            DataTable table = db.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            for (int i = 0; i < 200; i++)
            {
                var row = table.NewRow();
                row["ID"] = i;
                table.Rows.Add(row);
            }
            string query = "Update TOP(50)  [TBL] set ID=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(50, affected, "There should be 50 row affected");

            int count = 0;
            for (int i = 0; i < 200; i++)
            {
                if (table.Rows[i]["ID"].Equals(2))
                    count++;
            }
            Assert.AreEqual(50, affected, "There was suposed to be 50 rows with the updated ID");
        }

        [TestMethod]
        public void TopPercentUpdateTest()
        {
            var db = new Database();
            DataTable table = db.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            for (int i = 0; i < 200; i++)
            {
                var row = table.NewRow();
                row["ID"] = i;
                table.Rows.Add(row);
            }
            string query = "Update TOP(50) PERCENT [TBL] set ID=2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(100, affected, "There should be 100 row affected");
            int count = 0;
            for (int i = 0; i < 200; i++)
            {
                if (table.Rows[i]["ID"].Equals(2))
                    count++;
            }
            Assert.AreEqual(100, affected, "There was suposed to be 100 rows with the updated ID");
        }
        
        [TestMethod]
        public void UpdateWhereEquals()
        {
            var db = new Database();
            DataTable table = db.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            for (int i = 0; i < 100; i++)
            {
                var row = table.NewRow();
                row["ID"] = i;
                table.Rows.Add(row);
            }
            string query = "Update [TBL] set [ID]=5 where [ID] = 1";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be 1 row affected");
            int count = 0;
            for (int i = 0; i < 100; i++)
            {
                if (table.Rows[i]["ID"].Equals(5))
                    count++;
            }
            Assert.AreEqual(2, count, "There was suposed to be 2 rows with the updated ID");
        }
    }
}
