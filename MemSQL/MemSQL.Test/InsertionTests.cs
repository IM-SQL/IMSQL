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
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count, "There should be one row on the table");
            Assert.AreEqual(3, table.Rows[0]["ID"], "The inserted value was not present on the table");
        }
        [TestMethod]
        public void MultivaluedInsertTest()
        {
            DataSet ds = new DataSet();
            DataTable table = ds.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("A", typeof(int)));
            table.Columns.Add(new DataColumn("B", typeof(string)));
            string query = "Insert into [TBL] values(3,'asd')";

            SQLInterpreter interpreter = new SQLInterpreter(ds);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count, "There should be one row on the table");
            Assert.AreEqual(3, table.Rows[0]["A"], "The inserted value was not present on the table");
            Assert.AreEqual("asd", table.Rows[0]["B"], "The inserted value was not present on the table");
        }
        [TestMethod]
        public void InsertIdentityShouldFail()
        {
            DataSet ds = new DataSet();
            DataTable table = ds.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("A", typeof(int)));

            table.Columns["A"].AutoIncrement = true;
            table.Columns["A"].AutoIncrementSeed = 1;
            table.Columns["A"].AutoIncrementStep = 1; 
            string query = "Insert into [TBL](A) values(3)";

            SQLInterpreter interpreter = new SQLInterpreter(ds);
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
            //Sql says 
            //Msg 544, Level 16, State 1, Line 4
            //Cannot insert explicit value for identity column in table 'TBL' when IDENTITY_INSERT is set to OFF.
                interpreter.Execute(query);
            });
        }
       
        [TestMethod]
        public void DefaultValueInsertTest()
        {
            DataSet ds = new DataSet();
            DataTable table = ds.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("A", typeof(int)));
            table.Columns.Add(new DataColumn("B", typeof(int)));
            table.Columns["B"].DefaultValue = 5;
            string query = "Insert into [TBL](A) values(3)";

            SQLInterpreter interpreter = new SQLInterpreter(ds);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count, "There should be one row on the table");
            Assert.AreEqual(3, table.Rows[0]["A"], "The inserted value was not present on the table");
            Assert.AreEqual(5, table.Rows[0]["B"], "The Default value was not present on the table");

        }

        [TestMethod]
        public void DBNULLInsertTest()
        {
            DataSet ds = new DataSet();
            DataTable table = ds.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("A", typeof(int)));
            table.Columns[0].AllowDBNull = true;
            string query = "Insert into [TBL] values(NULL)";

            SQLInterpreter interpreter = new SQLInterpreter(ds);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count, "There should be one row on the table");
            Assert.AreEqual(DBNull.Value, table.Rows[0]["A"], "The inserted value was not present on the table");
        }

        [TestMethod]
        public void UnorderedValuesTest()
        {
            DataSet ds = new DataSet();
            DataTable table = ds.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("A", typeof(int)));
            table.Columns.Add(new DataColumn("B", typeof(int)));
            string query = "Insert into [TBL](B,A) values(2,1)";

            SQLInterpreter interpreter = new SQLInterpreter(ds);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count, "There should be one row on the table");
            Assert.AreEqual(1, table.Rows[0]["A"], "The inserted value was not present on the table");
            Assert.AreEqual(2, table.Rows[0]["B"], "The inserted value was not present on the table");
        }

        [TestMethod]
        public void SelectedValuesTest()
        {
            DataSet ds = new DataSet();
            DataTable table = ds.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("A", typeof(int)));
            table.Columns.Add(new DataColumn("B", typeof(int)));
            table.Columns.Add(new DataColumn("C", typeof(int)));
            table.Columns["C"].AllowDBNull = true;
            string query = "Insert into [TBL](B,A) values(2,1)";

            SQLInterpreter interpreter = new SQLInterpreter(ds);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count, "There should be one row on the table");
            Assert.AreEqual(1, table.Rows[0]["A"], "The inserted value was not present on the table");
            Assert.AreEqual(2, table.Rows[0]["B"], "The inserted value was not present on the table");
            Assert.AreEqual(DBNull.Value, table.Rows[0]["C"], "The default value was not present on the table");
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
            Func<Tuple<int, int>, string> printTuple = (t) => { return string.Format("( {0} , {1} )", t.Item1, t.Item2); };

            DataSet ds = new DataSet();
            DataTable table = ds.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("A", typeof(int)));
            table.Columns.Add(new DataColumn("B", typeof(int)));

            string query =
                string.Format(
                "Insert into [TBL] values {0}", string.Join(", ", testData.Select(t => printTuple(t))));

            SQLInterpreter interpreter = new SQLInterpreter(ds);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(testData.Count, affected, "The amount of rows affected is wrong");
            Assert.AreEqual(testData.Count, table.Rows.Count, "All the test data should have been inserted");
            for (int i = 0; i < testData.Count; i++)
            {
                Assert.AreEqual(testData[i].Item1, table.Rows[i]["A"], "The inserted value was not present on the table");
                Assert.AreEqual(testData[i].Item2, table.Rows[i]["B"], "The inserted value was not present on the table");
            }
        }

        [TestMethod]
        public void UnsufficientParametersWithoutFieldNameShouldFail()
        {
            DataSet ds = new DataSet();
            DataTable table = ds.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("A", typeof(int)));
            table.Columns.Add(new DataColumn("B", typeof(int)));
            string query = "Insert into [TBL] values(3)";

            SQLInterpreter interpreter = new SQLInterpreter(ds);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                //Sql says 
                //Msg 213, Level 16, State 1, Line 1
                //Column name or number of supplied values does not match table definition.
                interpreter.Execute(query);
            });
        }
        [TestMethod]
        public void UnsufficientParametersWithoutFieldNameEvenWithDefaultValuesShouldFail()
        {
            DataSet ds = new DataSet();
            DataTable table = ds.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("A", typeof(int)));
            table.Columns.Add(new DataColumn("B", typeof(int)));
            table.Columns["A"].DefaultValue = 5;
            string query = "Insert into [TBL] values(3)";

            SQLInterpreter interpreter = new SQLInterpreter(ds);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                //Sql says 
                //Msg 213, Level 16, State 1, Line 1
                //Column name or number of supplied values does not match table definition.
                interpreter.Execute(query);
            });
        }
        [TestMethod]
        public void UnsifficientParametersWithoutNameShouldNotConsiderIdentityColumns()
        {
            DataSet ds = new DataSet();
            DataTable table = ds.Tables.Add("TBL");
            table.Columns.Add(new DataColumn("A", typeof(int)));
            table.Columns.Add(new DataColumn("B", typeof(string)));
            table.Columns["A"].AutoIncrement = true;
            table.Columns["A"].AutoIncrementSeed = 1;
            table.Columns["A"].AutoIncrementStep = 1;

            string query = "Insert into [TBL] values('asd')";

            SQLInterpreter interpreter = new SQLInterpreter(ds);
            var result = interpreter.Execute(query);
            Assert.AreEqual(1, result.RowsAffected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count, "There should be one row on the table");
            Assert.AreEqual(1, table.Rows[0]["A"], "The inserted value was not present on the table");
            Assert.AreEqual("asd", table.Rows[0]["B"], "The inserted value was not present on the table");
        }
    }
}
