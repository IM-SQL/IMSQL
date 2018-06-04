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
    public class InsertionTests
    {
        [TestMethod]
        public void BasicInsertTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("ID", typeof(int)));
            string query = "Insert into [TBL] values(3)";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count(), "There should be one row on the table");
            Assert.AreEqual(3, table.GetRow(0)["ID"], "The inserted value was not present on the table");
        }

        [TestMethod]
        public void MultivaluedInsertTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("A", typeof(int)));
            table.AddColumn(new Column("B", typeof(string)));
            string query = "Insert into [TBL] values(3,'asd')";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count(), "There should be one row on the table");
            Assert.AreEqual(3, table.GetRow(0)["A"], "The inserted value was not present on the table");
            Assert.AreEqual("asd", table.GetRow(0)["B"], "The inserted value was not present on the table");
        }

        [TestMethod]
        public void InsertIdentityShouldFail()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("A", typeof(int)));

            table.GetColumn("A").AutoIncrement = true;
            table.GetColumn("A").AutoIncrementSeed = 1;
            table.GetColumn("A").AutoIncrementStep = 1;
            string query = "Insert into [TBL](A) values(3)";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                /*
                * INFO(Tera): This should fail. SQL Server 2014 throws the following error: 
                * Msg 544, Level 16, State 1, Line 4
                * Cannot insert explicit value for identity column in table 'TBL' when IDENTITY_INSERT is set to OFF.
                */
                interpreter.Execute(query);
            });
        }

        [TestMethod]
        public void DefaultValueInsertTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("A", typeof(int)));
            table.AddColumn(new Column("B", typeof(int)));
            table.GetColumn("B").DefaultValue = 5;
            string query = "Insert into [TBL](A) values(3)";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;
            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count(), "There should be one row on the table");
            Assert.AreEqual(3, table.GetRow(0)["A"], "The inserted value was not present on the table");
            Assert.AreEqual(5, table.GetRow(0)["B"], "The Default value was not present on the table");
        }

        [TestMethod]
        public void DBNULLInsertTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("A", typeof(int)));
            table.GetColumn(0).AllowDBNull = true;
            string query = "Insert into [TBL] values(NULL)";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count(), "There should be one row on the table");
            Assert.AreEqual(null, table.GetRow(0)["A"], "The inserted value was not present on the table");
        }

        [TestMethod]
        public void UnorderedValuesTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("A", typeof(int)));
            table.AddColumn(new Column("B", typeof(int)));
            string query = "Insert into [TBL](B,A) values(2,1)";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count(), "There should be one row on the table");
            Assert.AreEqual(1, table.GetRow(0)["A"], "The inserted value was not present on the table");
            Assert.AreEqual(2, table.GetRow(0)["B"], "The inserted value was not present on the table");
        }

        [TestMethod]
        public void SelectedValuesTest()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("A", typeof(int)));
            table.AddColumn(new Column("B", typeof(int)));
            table.AddColumn(new Column("C", typeof(int)));
            table.GetColumn("C").AllowDBNull = true;
            string query = "Insert into [TBL](B,A) values(2,1)";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count(), "There should be one row on the table");
            Assert.AreEqual(1, table.GetRow(0)["A"], "The inserted value was not present on the table");
            Assert.AreEqual(2, table.GetRow(0)["B"], "The inserted value was not present on the table");
            Assert.AreEqual(null, table.GetRow(0)["C"], "The default value was not present on the table");
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
            Func<Tuple<int, int>, string> printTuple = (t) => string.Format("( {0} , {1} )", t.Item1, t.Item2);

            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("A", typeof(int)));
            table.AddColumn(new Column("B", typeof(int)));

            string query =
                string.Format(
                "Insert into [TBL] values {0}", string.Join(", ", testData.Select(t => printTuple(t))));

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(testData.Count, affected, "The amount of rows affected is wrong");
            Assert.AreEqual(testData.Count, table.Rows.Count(), "All the test data should have been inserted");
            for (int i = 0; i < testData.Count; i++)
            {
                Assert.AreEqual(testData[i].Item1, table.GetRow(i)["A"], "The inserted value was not present on the table");
                Assert.AreEqual(testData[i].Item2, table.GetRow(i)["B"], "The inserted value was not present on the table");
            }
        }

        [TestMethod]
        public void InsufficientParametersWithoutFieldNameShouldFail()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("A", typeof(int)));
            table.AddColumn(new Column("B", typeof(int)));
            string query = "Insert into [TBL] values(3)";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                /*
                 * INFO(Tera): This should fail. SQL Server 2014 throws the following error: 
                 * Msg 213, Level 16, State 1, Line 4
                 * Column name or number of supplied values does not match table definition.
                 */
                interpreter.Execute(query);
            });
        }

        [TestMethod]
        public void InsufficientParametersWithoutFieldNameEvenWithDefaultValuesShouldFail()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("A", typeof(int)));
            table.AddColumn(new Column("B", typeof(int)));
            table.GetColumn("A").DefaultValue = 5;
            string query = "Insert into [TBL] values(3)";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                /*
                 * INFO(Tera): This should fail. SQL Server 2014 throws the following error: 
                 * Msg 213, Level 16, State 1, Line 4
                 * Column name or number of supplied values does not match table definition.
                 */
                interpreter.Execute(query);
            });
        }

        [TestMethod]
        public void InsufficientParametersWithoutNameShouldNotConsiderIdentityColumns()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("A", typeof(int)));
            table.AddColumn(new Column("B", typeof(string)));
            table.GetColumn("A").AutoIncrement = true;
            table.GetColumn("A").AutoIncrementSeed = 1;
            table.GetColumn("A").AutoIncrementStep = 1;

            string query = "Insert into [TBL] values('asd')";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query);
            Assert.AreEqual(1, result.RowsAffected, "There should be one row affected");
            Assert.AreEqual(1, table.Rows.Count(), "There should be one row on the table");
            Assert.AreEqual(1, table.GetRow(0)["A"], "The inserted value was not present on the table");
            Assert.AreEqual("asd", table.GetRow(0)["B"], "The inserted value was not present on the table");
        }

        [TestMethod]
        public void EnumeratingResultsShouldNotExecuteInsertStatementTwice()
        {
            var db = new Database();
            {
                Table table = db.AddTable("TBL");
                table.AddColumn(new Column("Id", typeof(int))
                {
                    AutoIncrement = true,
                    AutoIncrementSeed = 1,
                    AutoIncrementStep = 1,
                });
                table.AddColumn(new Column("Name", typeof(string)));
                db.AddConstraint(new UniqueConstraint("TBL_PK", new[] { table.GetColumn("Id") }, true));
            }

            var interpreter = new SQLInterpreter(db);
            string query = "insert into TBL ([Name]) values ('Richo')";
            var result = interpreter.Execute(query);

            // Enumerating all records should have no effect
            foreach (var table in result.Values)
            {
                foreach (var row in table.Records)
                {
                    foreach (var col in table.Columns)
                    {
                        Console.WriteLine(row[col.ColumnName]);
                    }
                }
            }
            // Sending ToString() also enumerates the records
            Console.WriteLine(result.ToString());

            Assert.AreEqual(1, result.RowsAffected, "There should be one row affected");
            Assert.AreEqual(1, db.GetTable("TBL").Rows.Count(), "There should be one row on the table");
            Assert.AreEqual(1, db.GetTable("TBL").GetRow(0)["Id"], "The Id should be set correctly");
        }

        [TestMethod]
        public void InsertingNULLInAnImplicitlyNullableColumn()
        {
            var db = new Database();
            var interpreter = new SQLInterpreter(db);
            interpreter.Execute(@"
                create table Customer
                (
                 Id int primary key identity,
                 [Name] nvarchar(50) not null,
                 [Timestamp] datetime,
                 [Enabled] bit default 1
                )");

            var result = interpreter.Execute("insert into Customer ([Name]) values ('Richo'),('Diego'),('Sofía')");

            Assert.AreEqual(3, result.RowsAffected, "Three rows should be inserted");
            Assert.AreEqual(3, db.GetTable("Customer").Rows.Count(), "There should be 3 rows in the table");
            Assert.IsNull(db.GetTable("Customer").GetRow(0)["Timestamp"], "The field value should be null");
        }
        [TestMethod]
        public void InsertWithoutOutputShouldNotReturnValues()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("A", typeof(int)));
            table.AddColumn(new Column("B", typeof(string)));
            string query = "Insert into [TBL] values(3,'asd')";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(0, result.Values.Length, "No result should have been returned");
        }
        [TestMethod]
        public void InsertWithOutput()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("A", typeof(int)));
            table.AddColumn(new Column("B", typeof(string)));
            string query = "Insert into [TBL] output inserted.* values(3,'asd')";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, result.Values.Length, "One result should have been returned");
            var resultSet = result.Values[0];
            Assert.AreEqual(2, resultSet.Columns.Count(), "The result should have two columns");
            Assert.AreEqual("A", resultSet.Columns.ElementAt(0).ColumnName, "Failed to find the expected column");
            Assert.AreEqual("B", resultSet.Columns.ElementAt(1).ColumnName, "Failed to find the expected column");

            Assert.AreEqual(1, resultSet.Records.Count(), "There should be one row");
            var row = resultSet.Records.ElementAt(0);

            Assert.AreEqual(3, row["A"], "The expected result was not present in the row");
            Assert.AreEqual("asd", row["B"], "The expected result was not present in the row");

        }
        [TestMethod]
        public void InsertWithSelectiveOutput()
        {
            var db = new Database();
            Table table = db.AddTable("TBL");
            table.AddColumn(new Column("A", typeof(int)));
            table.AddColumn(new Column("B", typeof(string)));
            string query = "Insert into [TBL] output inserted.A values(3,'asd')";

            SQLInterpreter interpreter = new SQLInterpreter(db);
            var result = interpreter.Execute(query);
            int affected = result.RowsAffected;

            Assert.AreEqual(1, affected, "There should be one row affected");
            Assert.AreEqual(1, result.Values.Length, "One result should have been returned");
            var resultSet = result.Values[0];
            Assert.AreEqual(1, resultSet.Columns.Count(), "The result should have two columns");
            Assert.AreEqual("A", resultSet.Columns.ElementAt(0).ColumnName, "Failed to find the expected column");

            Assert.AreEqual(1, resultSet.Records.Count(), "There should be one row");
            var row = resultSet.Records.ElementAt(0);

            Assert.AreEqual(3, row["A"], "The expected result was not present in the row"); 

        }
    }
}
