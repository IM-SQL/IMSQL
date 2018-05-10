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
            Assert.IsTrue(table.PrimaryKey.Length == 1, "The Primary Key is missing!");
            Assert.AreEqual(table.Columns["ID"], table.PrimaryKey[0]);
        }

        [TestMethod]
        public void FKCreationTest()
        {
            string script = "Create table [TBL](col1 int NOT NULL Primary Key)";
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);

            int rows = visitor.Execute(script);
            Assert.IsTrue(ds.Tables.Contains("TBL"), "The table must be created");
            var table = ds.Tables["TBL"];
            Assert.IsTrue(table.Columns.Contains("col1"));
            Assert.AreEqual(typeof(int), table.Columns["col1"].DataType);
            Assert.IsTrue(table.PrimaryKey.Length == 1, "The Primary Key is missing!");
            Assert.AreEqual(table.Columns["col1"], table.PrimaryKey[0]);


            string script2= "Create table [TBL2](col2 int NOT NULL Primary Key, " +
                "CONSTRAINT FK_tbl FOREIGN KEY (col2)     REFERENCES TBL(col1))";

            rows = visitor.Execute(script2);
            Assert.IsTrue(ds.Tables.Contains("TBL2"), "The table must be created");
            var table2 = ds.Tables["TBL2"];
            Assert.IsTrue(table2.Columns.Contains("col2"));
            Assert.AreEqual(typeof(int), table2.Columns["col2"].DataType);
            Assert.IsTrue(table2.PrimaryKey.Length == 1, "The Primary Key is missing!");
            Assert.AreEqual(table2.Columns["col2"], table2.PrimaryKey[0]);


            Assert.IsTrue(table2.Constraints.Count == 2, "Either the PK or the FK are missing");
            Assert.IsTrue(table2.Constraints.Contains("FK_tbl"),"The FK was not found by name");
            var fk = table2.Constraints["FK_tbl"] as ForeignKeyConstraint;
            Assert.IsTrue(fk.Columns.Length == 1);
            Assert.AreEqual("col2", fk.Columns[0].ColumnName);
            Assert.AreEqual(table2, fk.Table,"The child table is not the correct one");

            Assert.IsTrue(fk.RelatedColumns.Length == 1);
            Assert.AreEqual("col1", fk.Columns[0].ColumnName);
            Assert.AreEqual(table, fk.RelatedTable, "The parent table is not the correct one");
        }


        [TestMethod]
        public void ComputedColumnCreationTest()
        {
            string script = "CREATE TABLE [cTest](  " +
                "[num] INT NOT NULL," +
                "  [calc]  AS" +
                "    CASE WHEN num < 0" +
                "      THEN(num * 2)" +
                "      ELSE(num +2)" +
                "    END)";
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            int rows = visitor.Execute(script);
            Assert.IsTrue(ds.Tables.Contains("TBL"), "The table must be created");
            var table = ds.Tables["TBL"];
            Assert.IsTrue(table.Columns.Contains("num"));
            Assert.AreEqual(typeof(int), table.Columns["num"].DataType);
            Assert.IsTrue(table.Columns.Contains("calc"));
            Assert.AreEqual(typeof(int), table.Columns["calc"].DataType);
            var dr1 = table.NewRow();
            dr1["num"] = 1;
            Assert.AreEqual(3, dr1["calc"]);
            dr1["num"] = -5;
            Assert.AreEqual(-10, dr1["calc"]);
        }


    }
}
