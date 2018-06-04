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
    public class SelectionTests
    {
        [TestMethod]
        public void BasicSelectTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));

            var row = table.NewRow(3);

            table.AddRow(row);

            string query = "Select * from [TBL]";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(3, result.Values.Records.First()["ID"], "The selected value was not present on the Table");
        }
        [TestMethod]
        public void SomeFieldsSelectTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("col1", typeof(int)));
            table.AddColumn(new Column("col2", typeof(int)));

            var row = table.NewRow(1, 2);

            table.AddRow(row);

            string query = "Select col2 from [TBL]";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreNotEqual(null, result.Values, "There should be only one result set");
            Assert.AreEqual(1, result.Values.Columns.Count(), "There should be only one column");
            Assert.AreEqual("col2", result.Values.Columns.ElementAt(0).ColumnName, "The expected column was not on the result set");
            Assert.AreEqual(1, result.Values.Records.Count(), "There should be only one row");
            Assert.AreEqual(2, result.Values.Records.ElementAt(0).ItemArray[0], "The selected value was not present on the Table");
        }

        [TestMethod]
        public void SelectWithAlias()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));

            var row = table.NewRow(3);

            table.AddRow(row);

            string query = "Select ID as A from [TBL]";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, result.Values.Columns.Count(), "There should be only one column");
            Assert.AreEqual("A", result.Values.Columns.ElementAt(0).ColumnName, "The expected column was not on the result set");
            Assert.AreEqual(3, result.Values.Records.First()["A"], "The selected value was not present on the Table");
        }
        [TestMethod]
        public void SelectWithExpression()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));

            var row = table.NewRow(3);

            table.AddRow(row);

            string query = "Select ID, ID*2 from [TBL]";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(2, result.Values.Columns.Count(), "There should be only one column");
            var data = result.Values.Records.First().ItemArray;
            Assert.AreEqual(3, data[0], "The selected value was not present on the Table");
            Assert.AreEqual(6, data[1], "The calculated value was not present on the Table");
        }
        [TestMethod]
        public void SelectWithoutTable()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));

            var row = table.NewRow(3);

            table.AddRow(row);

            string query = "Select 7";
            SQLInterpreter interpreter = new SQLInterpreter(db);

            var result = interpreter.Execute(query)[0];
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, result.Values.Columns.Count(), "There should be only one column");
            var data = result.Values.Records.First().ItemArray;
            Assert.AreEqual(7, data[0], "The selected value was not present on the Table");

        }
    }
}
