﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSQL.Test
{
    [TestClass]
    public class DeletionTests
    {
        [TestMethod]
        public void BasicDeleteTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));

            var row = table.NewRow(3);
            table.AddRow(row);

            string query = "Delete from [TBL]";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(0, table.Rows.Count(), "There should be no rows on the table");
            Assert.IsTrue(row.RowState == DataRowState.Detached, "The created row should have been detached because it is no longer in the table");
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 100; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Delete from [TBL]";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(100, affected, "There should be 100 row affected");
            Assert.AreEqual(0, table.Rows.Count(), "There should be no rows on the table");
        }

        [TestMethod]
        public void TopDeleteTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 200; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Delete TOP(50) from [TBL]";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(50, affected, "There should be 50 row affected");
            Assert.AreEqual(150, table.Rows.Count(), "There should be 150 rows on the table");
        }

        [TestMethod]
        public void TopDeleteWithTiesShouldFail()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 200; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Delete TOP(50) with ties from [TBL]";
            SQLInterpreter interpreter = new SQLInterpreter(db);
            Assert.ThrowsException<ParseException>(() =>
            {
                interpreter.Execute(query);
            });
        }

        [TestMethod]
        public void TopPercentDeleteTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 200; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Delete TOP (50) PERCENT from [TBL]";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(100, affected, "There should be 100 row affected");
            Assert.AreEqual(100, table.Rows.Count(), "There should be 100 rows on the table");
        }

        [TestMethod]
        public void DeleteWhereEquals()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 100; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Delete from [TBL] where [ID] = 1";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be 1 row affected");
            Assert.AreEqual(99, table.Rows.Count(), "There should be 99 rows on the table");
        }

        [TestMethod]
        public void DeleteWhereNotEqualsE()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 100; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Delete from [TBL] where [ID] != 1";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(99, affected, "There should be 99 row affected");
            Assert.AreEqual(1, table.Rows.Count(), "There should be 1 rows on the table");
        }

        [TestMethod]
        public void DeleteWhereNotEqualsB()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 100; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Delete from [TBL] where [ID] <> 1";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(99, affected, "There should be 99 row affected");
            Assert.AreEqual(1, table.Rows.Count(), "There should be 1 rows on the table");
        }

        [TestMethod]
        public void DeleteWhereLT()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 100; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Delete from [TBL] where [ID] < 2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(2, affected, "There should be 2 row affected");
            Assert.AreEqual(98, table.Rows.Count(), "There should be 98 rows on the table");
        }

        [TestMethod]
        public void DeleteWhereGT()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 100; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Delete from [TBL] where [ID] > 97";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(2, affected, "There should be 2 row affected");
            Assert.AreEqual(98, table.Rows.Count(), "There should be 98 rows on the table");
        }

        [TestMethod]
        public void DeleteWhereLTE()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 100; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Delete from [TBL] where [ID] <= 2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(3, affected, "There should be 3 row affected");
            Assert.AreEqual(97, table.Rows.Count(), "There should be 97 rows on the table");
        }

        [TestMethod]
        public void DeleteWhereNLT()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 100; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Delete from [TBL] where [ID] !< 97";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(3, affected, "There should be 3 row affected");
            Assert.AreEqual(97, table.Rows.Count(), "There should be 97 rows on the table");
        }

        [TestMethod]
        public void DeleteWhereNGT()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 100; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Delete from [TBL] where [ID] !> 2";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(3, affected, "There should be 3 row affected");
            Assert.AreEqual(97, table.Rows.Count(), "There should be 97 rows on the table");
        }

        [TestMethod]
        public void DeleteWhereGTE()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 100; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Delete from [TBL] where [ID] >= 97";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(3, affected, "There should be 3 row affected");
            Assert.AreEqual(97, table.Rows.Count(), "There should be 97 rows on the table");
        }

        [TestMethod]
        public void DeleteWhereNot()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 100; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Delete from [TBL] where not [ID] = 1";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(99, affected, "There should be 1 row affected");
            Assert.AreEqual(1, table.Rows.Count(), "There should be 99 rows on the table");
        }

        [TestMethod]
        public void DeleteWhereAnd()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 100; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Delete from [TBL] where [ID] > 1 AND [ID] < 5";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(3, affected, "There should be 3 row affected");
            Assert.AreEqual(97, table.Rows.Count(), "There should be 97 rows on the table");
        }

        [TestMethod]
        public void DeleteWhereOr()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            for (int i = 0; i < 100; i++)
            {
                var row = table.NewRow(i);
                table.AddRow(row);
            }
            string query = "Delete from [TBL] where [ID] < 1 OR [ID] > 98";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(2, affected, "There should be 2 row affected");
            Assert.AreEqual(98, table.Rows.Count(), "There should be 98 rows on the table");
        }
        [TestMethod]
        public void DeleteWithoutOutputShouldNotReturnValues()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("A", typeof(int)));
            table.AddColumn(new Column("B", typeof(string)));
            var row = table.NewRow(3, "asd");
            table.AddRow(row);
            string query = "delete from [TBL] ";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(null, result.Values, "No result should have been returned");
        }
        [TestMethod]
        public void DeleteWithOutput()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("A", typeof(int)));
            table.AddColumn(new Column("B", typeof(string)));
            var r = table.NewRow(3, "asd");
            table.AddRow(r);
            string query = "delete from [TBL] output deleted.* ";

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

            Assert.AreEqual(3, row["A"], "The expected result was not present in the row");
            Assert.AreEqual("asd", row["B"], "The expected result was not present in the row");

        }
        [TestMethod]
        public void DeleteWithSelectiveOutput()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("A", typeof(int)));
            table.AddColumn(new Column("B", typeof(string)));
            var r = table.NewRow(3, "asd");
            table.AddRow(r);
            string query = "delete from [TBL] output deleted.A ";

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

            Assert.AreEqual(3, row["A"], "The expected result was not present in the row");

        }
    }
}
