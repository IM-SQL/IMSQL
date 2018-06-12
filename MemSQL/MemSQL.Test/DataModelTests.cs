using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
