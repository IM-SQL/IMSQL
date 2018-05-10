using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemSQL;
using System.Collections.Generic;
using System.Data;

namespace MemSQL.Test.Strcutural
{
    [TestClass]
    public class CreationTests
    {
        [TestMethod]
        public void basicTableCreationTest()
        {
            string script = "Create table [TBL](col1 int,col2 varchar(3),col3 bit)";
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            int rows = visitor.Execute(script);
            Assert.IsTrue(ds.Tables.Contains("TBL"), "The table must be created");
            var table = ds.Tables["TBL"];
            Assert.IsTrue(table.Columns.Contains("col1"));
            Assert.AreEqual(typeof(int), table.Columns["col1"].DataType);
            Assert.IsTrue(table.Columns.Contains("col2"));
            Assert.AreEqual(typeof(string), table.Columns["col2"].DataType);
            Assert.IsTrue(table.Columns.Contains("col3"));
            Assert.AreEqual(typeof(bool), table.Columns["col3"].DataType);
        }
        [TestMethod]
        public void TableCreationTest()
        {
            string script = "CREATE TABLE CUSTOMERS("
                            + "ID   INT              NOT NULL,"
                            + "NAME VARCHAR (20)     NOT NULL,"
                            + "BIRTHDAY  DATETIME    NOT NULL,"
                            + "ADDRESS  CHAR (25) ,"
                            + "SALARY   DECIMAL (18, 2),"
                            + "PRIMARY KEY (ID));";
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            int rows = visitor.Execute(script);
            Assert.IsTrue(ds.Tables.Contains("CUSTOMERS"), "The table must be created");
            var table = ds.Tables["CUSTOMERS"];
            Assert.IsTrue(table.Columns.Contains("ID"));
            Assert.AreEqual(typeof(int), table.Columns["ID"].DataType);
            Assert.IsTrue(table.Columns.Contains("NAME"));
            Assert.AreEqual(typeof(string), table.Columns["NAME"].DataType);
            Assert.IsTrue(table.Columns.Contains("BIRTHDAY"));
            Assert.AreEqual(typeof(DateTime), table.Columns["BIRTHDAY"].DataType);
            Assert.IsTrue(table.Columns.Contains("ADDRESS"));
            Assert.AreEqual(typeof(string), table.Columns["ADDRESS"].DataType);
            Assert.IsTrue(table.Columns.Contains("SALARY"));
            Assert.AreEqual(typeof(decimal), table.Columns["SALARY"].DataType);
            Assert.IsTrue(table.PrimaryKey.Length == 1,"The Primary Key is missing!");
            Assert.AreEqual(table.Columns["ID"], table.PrimaryKey[0]);
        }
    }
}
