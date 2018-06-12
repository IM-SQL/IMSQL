﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL.Test
{
    [TestClass]
    public class DataModelTests
    {
        [TestMethod]
        public void Test001CreateEmptyTable()
        {
            var db = new Database();
            var table = db.AddTable("T1");
            Assert.AreEqual("T1", table.TableName, "The table name should be set correctly");
            Assert.AreEqual(0, table.Rows.Count(), "The table should be empty");
        }

        [TestMethod]
        public void Test002CreateTableWithAllValidColumnDataTypes()
        {
            var db = new Database();
            var table = db.AddTable("T1");
            table.AddColumn(new Column("C01", typeof(Int32)));
            table.AddColumn(new Column("C02", typeof(Int64)));
            table.AddColumn(new Column("C03", typeof(Int16)));
            table.AddColumn(new Column("C04", typeof(Byte)));
            table.AddColumn(new Column("C05", typeof(Decimal)));
            table.AddColumn(new Column("C06", typeof(String)));
            table.AddColumn(new Column("C07", typeof(Boolean)));
            table.AddColumn(new Column("C08", typeof(Double)));
            table.AddColumn(new Column("C09", typeof(Single)));
            table.AddColumn(new Column("C10", typeof(DateTime)));
            table.AddColumn(new Column("C11", typeof(TimeSpan)));
            table.AddColumn(new Column("C12", typeof(DateTimeOffset)));
            table.AddColumn(new Column("C13", typeof(Byte[])));
            table.AddColumn(new Column("C14", typeof(Object)));
            table.AddColumn(new Column("C15", typeof(Guid)));

            Assert.AreEqual(15, table.Columns.Count(), "15 columns should be added");
            Assert.AreEqual(0, table.Rows.Count(), "The table should contain no rows");
            foreach (var col in table.Columns)
            {
                Assert.AreEqual(table, col.Table, "The table should be set for column {0}", col.ColumnName);
                Assert.AreEqual(col, table.GetColumn(col.ColumnName), "Accessing the column by name should work");
            }
        }

        [TestMethod]
        public void Test003CreateTableWithPK()
        {
            var db = new Database();
            var table = db.AddTable("T1");
            table.AddColumn(new Column("Id", typeof(int)));
            db.AddConstraint(new UniqueConstraint("T1_PK", new[] { table.GetColumn("Id") }, true));
            CollectionAssert.AreEqual(new[] { table.GetColumn("Id") }, table.PrimaryKey,
                "The PrimaryKey property should be set");
        }
        
        [TestMethod]
        public void Test004CreateTableWithCompositePK()
        {
            var db = new Database();
            var table = db.AddTable("T1");
            table.AddColumn(new Column("Id1", typeof(int)));
            table.AddColumn(new Column("Id2", typeof(string)));
            db.AddConstraint(new UniqueConstraint(
                constraintName: "T1_PK", 
                columns: new[] { table.GetColumn("Id1"), table.GetColumn("Id2") }, 
                isPrimaryKey: true));
            CollectionAssert.AreEqual(
                expected: new[] { table.GetColumn("Id1"), table.GetColumn("Id2") }, 
                actual: table.PrimaryKey,
                message: "The PrimaryKey property should be set");
        }

        [TestMethod]
        public void Test005InsertRowInEmptyTable()
        {
            var db = new Database();
            var table = db.AddTable("T1");

            Assert.ThrowsException<ArgumentException>(
                () => table.AddRow(1, 2, 3, "Richo"),
                "The table should not allow inserting any row");
            Assert.AreEqual(0, table.Rows.Count(), "The table should be empty");

            Assert.ThrowsException<ArgumentException>(
                () => table.NewRow(1, 2, 3, "Richo"),
                "The table should not allow to create any row");
            Assert.AreEqual(0, table.Rows.Count(), "The table should still be empty");
        }

        [TestMethod]
        public void Test006InsertRowInTableWithJustOneColumn()
        {
            var db = new Database();
            var table = db.AddTable("T1");
            table.AddColumn(new Column("Id", typeof(int)));

            table.AddRow(42);
            Assert.AreEqual(1, table.Rows.Count(), "The table should contain 1 row");
            Assert.AreEqual(42, table.GetRow(0)["Id"], "The row inserted is set correctly");

            Assert.ThrowsException<ArgumentException>(
                () => table.AddRow(1, 2, 3, "Richo"), 
                "The table should not allow inserting more columns than specified");
            Assert.AreEqual(1, table.Rows.Count(), "The table should still contain 1 row");

            Assert.ThrowsException<FormatException>(
                () => table.AddRow("Richo"),
                "The table should not allow inserting a column of a different type than specified");
            Assert.AreEqual(1, table.Rows.Count(), "The table should still contain 1 row");
        }

        [TestMethod]
        public void Test007InsertRowInTableWithJustAPK()
        {
            var db = new Database();
            var table = db.AddTable("T1");
            table.AddColumn(new Column("Id", typeof(int)));
            db.AddConstraint(new UniqueConstraint("T1_PK", new[] { table.GetColumn("Id") }, true));

            table.AddRow(42);
            Assert.AreEqual(1, table.Rows.Count(), "The table should contain 1 row");
            var row = table.GetRow(0);
            Assert.AreEqual(row, table.FindRow(42), "The row can be find by searching its PK");

            Assert.ThrowsException<ConstraintException>(
                () => table.AddRow(42),
                "The table should not allow inserting duplicated PK");
            Assert.AreEqual(1, table.Rows.Count(), "The table should still contain 1 row");
        }
    }
}
