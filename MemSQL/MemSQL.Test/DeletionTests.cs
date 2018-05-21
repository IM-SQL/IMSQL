﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [TestMethod]
        public void TopDeleteTest()
        {
            DataSet ds = new DataSet();
            DataTable table = ds.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            for (int i = 0; i < 200; i++)
            {
                var row = table.NewRow();
                row["ID"] = i;
                table.Rows.Add(row);
            }
            string query = "Delete TOP(50) from [TBL]";
            SQLInterpreter interpreter = new SQLInterpreter(ds);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(50, affected, "There should be 50 row affected");
            Assert.AreEqual(150, table.Rows.Count, "There should be 150 rows on the table");
        }
        [TestMethod]
        public void TopDeleteWithTiesShouldFail()
        {
            DataSet ds = new DataSet();
            DataTable table = ds.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            for (int i = 0; i < 200; i++)
            {
                var row = table.NewRow();
                row["ID"] = i;
                table.Rows.Add(row);
            }
            string query = "Delete TOP(50) with ties from [TBL]";
            SQLInterpreter interpreter = new SQLInterpreter(ds);
            Assert.ThrowsException<ParseException>(() => {

                var result = interpreter.Execute(query);
            });
        }
        [TestMethod]
        public void TopPercentDeleteTest()
        {
            DataSet ds = new DataSet();
            DataTable table = ds.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            for (int i = 0; i < 200; i++)
            {
                var row = table.NewRow();
                row["ID"] = i;
                table.Rows.Add(row);
            }
            string query = "Delete TOP (50) PERCENT from [TBL]";
            SQLInterpreter interpreter = new SQLInterpreter(ds);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(100, affected, "There should be 100 row affected");
            Assert.AreEqual(100, table.Rows.Count, "There should be 100 rows on the table");
        }

        [TestMethod]
        public void DeleteWhereEquals()
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
            string query = "Delete from [TBL] where [ID] = 1";
            SQLInterpreter interpreter = new SQLInterpreter(ds);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be 1 row affected");
            Assert.AreEqual(99, table.Rows.Count, "There should be 99 rows on the table");
        }
        [TestMethod]
        public void DeleteWhereNotEqualsE()
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
            string query = "Delete from [TBL] where [ID] != 1";
            SQLInterpreter interpreter = new SQLInterpreter(ds);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(99, affected, "There should be 99 row affected");
            Assert.AreEqual(1, table.Rows.Count, "There should be 1 rows on the table");
        }
        [TestMethod]
        public void DeleteWhereNotEqualsB()
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
            string query = "Delete from [TBL] where [ID] <> 1";
            SQLInterpreter interpreter = new SQLInterpreter(ds);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(99, affected, "There should be 99 row affected");
            Assert.AreEqual(1, table.Rows.Count, "There should be 1 rows on the table");
        }

        [TestMethod]
        public void DeleteWhereLT()
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
            string query = "Delete from [TBL] where [ID] < 2";
            SQLInterpreter interpreter = new SQLInterpreter(ds);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(2, affected, "There should be 2 row affected");
            Assert.AreEqual(98, table.Rows.Count, "There should be 98 rows on the table");
        }
        [TestMethod]
        public void DeleteWhereGT()
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
            string query = "Delete from [TBL] where [ID] > 97";
            SQLInterpreter interpreter = new SQLInterpreter(ds);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(2, affected, "There should be 2 row affected");
            Assert.AreEqual(98, table.Rows.Count, "There should be 98 rows on the table");
        }

        [TestMethod]
        public void DeleteWhereLTE()
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
            string query = "Delete from [TBL] where [ID] <= 2";
            SQLInterpreter interpreter = new SQLInterpreter(ds);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(3, affected, "There should be 3 row affected");
            Assert.AreEqual(97, table.Rows.Count, "There should be 97 rows on the table");
        }
        [TestMethod]
        public void DeleteWhereNLT()
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
            string query = "Delete from [TBL] where [ID] !< 97";
            SQLInterpreter interpreter = new SQLInterpreter(ds);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(3, affected, "There should be 3 row affected");
            Assert.AreEqual(97, table.Rows.Count, "There should be 97 rows on the table");
        }
        [TestMethod]
        public void DeleteWhereNGT()
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
            string query = "Delete from [TBL] where [ID] !> 2";
            SQLInterpreter interpreter = new SQLInterpreter(ds);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(3, affected, "There should be 3 row affected");
            Assert.AreEqual(97, table.Rows.Count, "There should be 97 rows on the table");
        }
        [TestMethod]
        public void DeleteWhereGTE()
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
            string query = "Delete from [TBL] where [ID] >= 97";
            SQLInterpreter interpreter = new SQLInterpreter(ds);

            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(3, affected, "There should be 3 row affected");
            Assert.AreEqual(97, table.Rows.Count, "There should be 97 rows on the table");
        }
    }
}
