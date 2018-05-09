using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemSQL;
using System.Collections.Generic;
using System.Data;

namespace MemSQL.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TableCreationTest()
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
    }
}
