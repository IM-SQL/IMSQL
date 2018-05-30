using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemSQL;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MemSQL.Test.Structural
{
    [TestClass]
    public class CreationTests
    {
        [TestMethod]
        public void BasicTableCreationTest()
        {
            string script = "Create table [TBL](col1 int,col2 varchar(3),col3 bit)";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            var result = visitor.Execute(script);
            Assert.AreEqual(0, result.RowsAffected);
            Assert.IsTrue(db.ContainsTable("TBL"), "The table must be created");
            var table = db.GetTable("TBL");
            Assert.IsTrue(table.ContainsColumn("col1"));
            Assert.AreEqual(typeof(int), table.GetColumn("col1").DataType);
            Assert.IsTrue(table.ContainsColumn("col2"));
            Assert.AreEqual(typeof(string), table.GetColumn("col2").DataType);
            Assert.IsTrue(table.ContainsColumn("col3"));
            Assert.AreEqual(typeof(bool), table.GetColumn("col3").DataType);
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
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            var result = visitor.Execute(script);
            Assert.AreEqual(0, result.RowsAffected);
            Assert.IsTrue(db.ContainsTable("CUSTOMERS"), "The table must be created");
            var table = db.GetTable("CUSTOMERS");
            Assert.IsTrue(table.ContainsColumn("ID"));
            Assert.AreEqual(typeof(int), table.GetColumn("ID").DataType);
            Assert.IsTrue(table.ContainsColumn("NAME"));
            Assert.AreEqual(typeof(string), table.GetColumn("NAME").DataType);
            Assert.IsTrue(table.ContainsColumn("BIRTHDAY"));
            Assert.AreEqual(typeof(DateTime), table.GetColumn("BIRTHDAY").DataType);
            Assert.IsTrue(table.ContainsColumn("ADDRESS"));
            Assert.AreEqual(typeof(string), table.GetColumn("ADDRESS").DataType);
            Assert.IsTrue(table.ContainsColumn("SALARY"));
            Assert.AreEqual(typeof(decimal), table.GetColumn("SALARY").DataType);
            Assert.IsTrue(table.PrimaryKey.Length == 1, "The Primary Key is missing!");
            Assert.AreEqual(table.GetColumn("ID"), table.PrimaryKey[0]);
        }

        [TestMethod]
        public void DefaultValuesTableCreationTest()
        {
            string script = "Create table [TBL](" +
                "data int," +
                "col1 int DEFAULT 3," +
                "col2 varchar(3) DEFAULT 'asd'," +
                "col3 bit DEFAULT 1)";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            var result = visitor.Execute(script);
            Assert.AreEqual(0, result.RowsAffected);
            Assert.IsTrue(db.ContainsTable("TBL"), "The table must be created");
            var table = db.GetTable("TBL");
            Assert.IsTrue(table.ContainsColumn("col1"));
            Assert.AreEqual(typeof(int), table.GetColumn("col1").DataType);
            Assert.IsTrue(table.ContainsColumn("col2"));
            Assert.AreEqual(typeof(string), table.GetColumn("col2").DataType);
            Assert.IsTrue(table.ContainsColumn("col3"));
            Assert.AreEqual(typeof(bool), table.GetColumn("col3").DataType);
            
            var dr = table.NewRow(("data", 0));
            Assert.AreEqual(0, dr["data"], "The default value was not present on the row");
            Assert.AreEqual(3, dr["col1"], "The default value was not present on the row");
            Assert.AreEqual("asd", dr["col2"], "The default value was not present on the row");
            Assert.AreEqual(true, dr["col3"], "The default value was not present on the row");
        }

        [TestMethod]
        public void NullableTableCreationTest()
        {
            string script = "Create table [TBL](col1 int NOT NULL,col2 int NULL)";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            var result = visitor.Execute(script);
            Assert.AreEqual(0, result.RowsAffected);
            Assert.IsTrue(db.ContainsTable("TBL"), "The table must be created");
            var table = db.GetTable("TBL");
            Assert.IsTrue(table.ContainsColumn("col1"));
            Assert.AreEqual(typeof(int), table.GetColumn("col1").DataType);
            Assert.IsFalse(table.GetColumn("col1").AllowDBNull, "This column should not allow nulls");
            Assert.IsTrue(table.ContainsColumn("col2"));
            Assert.AreEqual(typeof(int), table.GetColumn("col2").DataType);
            Assert.IsTrue(table.GetColumn("col2").AllowDBNull, "This column should allow nulls");
        }

        [TestMethod]
        public void AutoincrementPKTableCreationTest()
        {
            string script = "Create table [TBL](ID int IDENTITY(3,3) PRIMARY KEY, DATA int)";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            var result = visitor.Execute(script);
            Assert.AreEqual(0, result.RowsAffected);
            Assert.IsTrue(db.ContainsTable("TBL"), "The table must be created");
            var table = db.GetTable("TBL");
            Assert.IsTrue(table.ContainsColumn("ID"));
            Assert.AreEqual(typeof(int), table.GetColumn("ID").DataType);
            Assert.IsTrue(table.PrimaryKey.Length == 1, "The Primary Key is missing!");
            Assert.AreEqual(table.GetColumn("ID"), table.PrimaryKey[0]);

            for (int i = 1; i < 10; i++)
            {
                var dr = table.NewRow(i);
                Assert.AreEqual(i * 3, dr["ID"], "The autonumeric field did not increment correctly");
            }
        }

        [TestMethod]
        public void InlinePKTableCreationTest()
        {
            string script = "Create table [TBL](ID int PRIMARY KEY)";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            var result = visitor.Execute(script);
            Assert.AreEqual(0, result.RowsAffected);
            Assert.IsTrue(db.ContainsTable("TBL"), "The table must be created");
            var table = db.GetTable("TBL");
            Assert.IsTrue(table.ContainsColumn("ID"));
            Assert.AreEqual(typeof(int), table.GetColumn("ID").DataType);
            Assert.IsTrue(table.PrimaryKey.Length == 1, "The Primary Key is missing!");
            Assert.AreEqual(table.GetColumn("ID"), table.PrimaryKey[0]);
        }

        [TestMethod]
        public void MultipleInlinedPKConstraintsShouldFail()
        {
            /*
             * INFO(Richo): This should fail. SQL Server 2016 throws the following error:
             * Cannot add multiple PRIMARY KEY constraints to table 'TBL'.
             */
            string script = "Create table [TBL](ID int PRIMARY KEY,ID2 int PRIMARY KEY)";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                visitor.Execute(script);
            });
            Assert.IsNull(db.GetTable("TBL"), "TBL should not exist");
        }

        [TestMethod]
        public void PKConstraintWithMultipleColumns()
        {
            string script = @"
                CREATE TABLE TBL
                (
                    [ID1] INT NOT NULL,
                    [ID2] INT NOT NULL
                    CONSTRAINT PK_TBL PRIMARY KEY ([ID1], [ID2])
                )";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            var result = visitor.Execute(script);
            Assert.AreEqual(0, result.RowsAffected);
            Assert.IsTrue(db.ContainsTable("TBL"), "The table must be created");
            var table = db.GetTable("TBL");
            Assert.IsTrue(table.ContainsColumn("ID1"));
            Assert.AreEqual(typeof(int), table.GetColumn("ID1").DataType);

            Assert.IsTrue(table.ContainsColumn("ID2"));
            Assert.AreEqual(typeof(int), table.GetColumn("ID2").DataType);

            Assert.IsTrue(table.PrimaryKey.Length == 2, "The Primary Key is missing!");
            Assert.AreEqual(table.GetColumn("ID1"), table.PrimaryKey[0]);
            Assert.AreEqual(table.GetColumn("ID2"), table.PrimaryKey[1]);
        }

        [TestMethod]
        public void FKCreationTest()
        {
            string script = "Create table [TBL](col1 int NOT NULL,PRIMARY KEY (col1))";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            var result = visitor.Execute(script);
            Assert.AreEqual(0, result.RowsAffected);
            Assert.IsTrue(db.ContainsTable("TBL"), "The table must be created");
            var table = db.GetTable("TBL");
            Assert.IsTrue(table.ContainsColumn("col1"));
            Assert.AreEqual(typeof(int), table.GetColumn("col1").DataType);
            Assert.IsTrue(table.PrimaryKey.Length == 1, "The Primary Key is missing!");
            Assert.AreEqual(table.GetColumn("col1"), table.PrimaryKey[0]);

            visitor = new SQLInterpreter(db);
            string script2 = "Create table [TBL2](col2 int NOT NULL,PRIMARY KEY (col2), " +
                "CONSTRAINT FK_tbl FOREIGN KEY (col2)     REFERENCES TBL(col1))";

            result = visitor.Execute(script2);
            Assert.IsTrue(db.ContainsTable("TBL2"), "The table must be created");
            var table2 = db.GetTable("TBL2");
            Assert.IsTrue(table2.ContainsColumn("col2"));
            Assert.AreEqual(typeof(int), table2.GetColumn("col2").DataType);
            Assert.IsTrue(table2.PrimaryKey.Length == 1, "The Primary Key is missing!");
            Assert.AreEqual(table2.GetColumn("col2"), table2.PrimaryKey[0]);

            Assert.AreEqual(2, table2.Constraints.Count(), "Either the PK or the FK are missing");
            Assert.IsTrue(db.ContainsConstraint("FK_tbl"), "The FK was not found by name");
            var fk = db.GetConstraint("FK_tbl") as ForeignKeyConstraint;
            Assert.IsTrue(fk.Columns.Length == 1);
            Assert.AreEqual("col2", fk.Columns[0].ColumnName);
            Assert.AreEqual(table2, fk.Table, "The child table is not the correct one");

            Assert.IsTrue(fk.RelatedColumns.Length == 1);
            Assert.AreEqual("col1", fk.RelatedColumns[0].ColumnName);
            Assert.AreEqual(table, fk.RelatedTable, "The parent table is not the correct one");
        }

        [TestMethod]
        public void ComputedColumnCreationTest()
        {
            string script = "CREATE TABLE [TBL](  " +
                "[num] INT NOT NULL," +
                "  [calc]  AS" +
                "    CASE WHEN num < 0" +
                "      THEN(num * 2)" +
                "      ELSE(num +2)" +
                "    END)";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            var result = visitor.Execute(script);
            Assert.AreEqual(0, result.RowsAffected);
            Assert.IsTrue(db.ContainsTable("TBL"), "The table must be created");
            var table = db.GetTable("TBL");
            Assert.IsTrue(table.ContainsColumn("num"));
            Assert.AreEqual(typeof(int), table.GetColumn("num").DataType);
            Assert.IsTrue(table.ContainsColumn("calc"));
            Assert.AreEqual(typeof(int), table.GetColumn("calc").DataType);
            var dr1 = table.NewRow(1);

            Assert.AreEqual(3, dr1["calc"]);
            dr1["num"] = -5;
            Assert.AreEqual(-10, dr1["calc"]);
        }

        [TestMethod]
        public void InvalidSyntaxShouldThrowAnException()
        {
            var script = "create table table (a int)";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            Assert.ThrowsException<ParseException>(() =>
            {
                visitor.Execute(script);
            });
            Assert.IsNull(db.GetTable("table"), "Table 'table' should not exist");
        }

        [TestMethod]
        public void FKToNonExistentTableShouldFail()
        {
            var script = @"
                CREATE TABLE [dbo].[TBL](
	                [Id] [int] IDENTITY(1,1) NOT NULL,
                    [ClientId] [int] NOT NULL,
                    CONSTRAINT [FK_TBL_Client] FOREIGN KEY ([ClientId]) REFERENCES [Client]([Id])
                )
                ";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            Assert.ThrowsException<NullReferenceException>(() =>
            {
                visitor.Execute(script);
            });
            Assert.IsNull(db.GetTable("TBL"), "TBL should not exist");
        }

        [TestMethod]
        public void FKFromNonExistentColumnShouldFail()
        {
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            {
                string script = "CREATE TABLE [Client] (ID int NOT NULL PRIMARY KEY)";
                visitor.Execute(script);
            }
            {
                var script = @"
                    CREATE TABLE [dbo].[TBL]
                    (
	                    [Id] [int] IDENTITY(1,1) NOT NULL,
                        CONSTRAINT [FK_TBL_CLIENT] FOREIGN KEY ([ClientId]) REFERENCES [Client]([Id])
                    )
                    ";
                Assert.ThrowsException<NullReferenceException>(() =>
                {
                    visitor.Execute(script);
                });
                Assert.IsNull(db.GetTable("TBL"), "TBL should not exist");
            }
        }

        [TestMethod]
        public void FKToNonExistentColumnShouldFail()
        {
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            {
                string script = "CREATE TABLE [Client] (ID2 int NOT NULL PRIMARY KEY)";
                visitor.Execute(script);
            }
            {
                var script = @"
                    CREATE TABLE [dbo].[TBL]
                    (
	                    [Id] [int] IDENTITY(1,1) NOT NULL,
                        [ClientId] [int] NOT NULL,
                        CONSTRAINT [FK_TBL_CLIENT] FOREIGN KEY ([ClientId]) REFERENCES [Client]([Id])
                    )
                    ";
                Assert.ThrowsException<NullReferenceException>(() =>
                {
                    visitor.Execute(script);
                });
                Assert.IsNull(db.GetTable("TBL"), "TBL should not exist");
            }
        }

        [TestMethod]
        public void MultipartTableNamesShouldUseTheLastIdentifier()
        {
            var script = "CREATE TABLE [dbo].[Client] (ID int NOT NULL PRIMARY KEY)";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            visitor.Execute(script);
            Assert.IsTrue(db.ContainsTable("Client"));
        }

        [TestMethod]
        public void IdentityPKWithoutArgsShouldUseDefaultValues()
        {
            string script = @"CREATE TABLE [dbo].[Client] ([Id] INT NOT NULL PRIMARY KEY IDENTITY)";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            visitor.Execute(script);

            var table = db.GetTable("Client");
            Assert.IsNotNull(table, "The table should be created");
            var col = table.GetColumn("Id");
            Assert.IsNotNull(col, "The PK should be valid");
            Assert.IsTrue(col.AutoIncrement, "Autoincrement should be set");
            Assert.AreEqual(1, col.AutoIncrementSeed, "Autoincrement seed should be 1");
            Assert.AreEqual(1, col.AutoIncrementStep, "Autoincrement step should be 1");
        }

        [TestMethod]
        public void MultipleUniqueConstraintsShouldBeAllowed()
        {
            string script = @"
                CREATE TABLE [dbo].[Client]
                (
	                [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
                    [Name] NVARCHAR(50) NOT NULL UNIQUE, 
                    [ExternalId] NVARCHAR(40) NOT NULL UNIQUE, 
                    [InternalId] NVARCHAR(40) NOT NULL UNIQUE
                )
                ";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            visitor.Execute(script);

            var table = db.GetTable("Client");
            Assert.IsNotNull(table, "The table should be created");
            CollectionAssert.AreEqual(new[] { "Id" },
                table.PrimaryKey.Select(c => c.ColumnName).ToArray(),
                "The PK should be configured correctly");

            string[] cols = new[] { "Id", "Name", "ExternalId", "InternalId" };
            for (int i = 0; i < cols.Length; i++)
            {
                var col = table.GetColumn(cols[i]);
                Assert.IsNotNull(col, "The column should exist");
                Assert.IsTrue(col.Unique, "Unique constraint should be set");
                Assert.IsFalse(col.AllowDBNull, "The column should not allow null");
            }
        }


        [TestMethod]
        public void AutomaticallyGeneratedConstraintNamesShouldNeverClash()
        {
            string script = @"
                CREATE TABLE [dbo].[Client]
                (
	                [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
                    [Name] NVARCHAR(50) NOT NULL, 
                    [ExternalId] NVARCHAR(40) NOT NULL, 
                    [InternalId] NVARCHAR(40) NOT NULL UNIQUE,
                    
                    CONSTRAINT PK_Client UNIQUE(Name),
                    CONSTRAINT UC_Client_ExternalId UNIQUE(ExternalId)  
                )
                ";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            visitor.Execute(script);

            var table = db.GetTable("Client");
            Assert.IsNotNull(table, "The table should be created");
            CollectionAssert.AreEqual(new[] { "Id" },
                table.PrimaryKey.Select(c => c.ColumnName).ToArray(),
                "The PK should be configured correctly");

            string[] cols = new[] { "Id", "Name", "ExternalId", "InternalId" };
            for (int i = 0; i < cols.Length; i++)
            {
                var col = table.GetColumn(cols[i]);
                Assert.IsNotNull(col, "The column should exist");
                Assert.IsTrue(col.Unique, "Unique constraint should be set");
                Assert.IsFalse(col.AllowDBNull, "The column should not allow null");
            }
        }

        [TestMethod]
        public void RecursiveFKShouldWork()
        {
            string script = @"
                CREATE TABLE [dbo].[LogException] 
                (
                    [id]             INT             IDENTITY (1, 1) NOT NULL,
                    [name]           NVARCHAR (512)  NOT NULL,
                    [message]        NVARCHAR (512)  NULL,
                    [stackTrace]     NVARCHAR (4000) NULL,
                    [source]         NVARCHAR (256)  NULL,
                    [innerException] INT             NULL,
                    PRIMARY KEY CLUSTERED ([id] ASC),
                    CONSTRAINT [FK_LogException_ToLogException] FOREIGN KEY ([innerException]) REFERENCES [dbo].[LogException] ([id])
                )";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            visitor.Execute(script);

            var table = db.GetTable("LogException");
            Assert.IsNotNull(table, "The table should exist");
            CollectionAssert.AreEqual(new[] { "id" },
                table.PrimaryKey.Select(c => c.ColumnName).ToArray(),
                "The PK should be configured correctly");

            Assert.IsTrue(db.ContainsConstraint("FK_LogException_ToLogException"));
        }

        [TestMethod]
        public void RecursiveFKAppliedBeforePKShouldWork()
        {
            string script = @"
                CREATE TABLE [dbo].[LogException] 
                (
                    [id]             INT             IDENTITY (1, 1) NOT NULL,
                    [name]           NVARCHAR (512)  NOT NULL,
                    [message]        NVARCHAR (512)  NULL,
                    [stackTrace]     NVARCHAR (4000) NULL,
                    [source]         NVARCHAR (256)  NULL,
                    [innerException] INT             NULL,
                    CONSTRAINT [FK_LogException_ToLogException] FOREIGN KEY ([innerException]) REFERENCES [dbo].[LogException] ([id]),
                    PRIMARY KEY CLUSTERED ([id] ASC)
                )";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            visitor.Execute(script);

            var table = db.GetTable("LogException");
            Assert.IsNotNull(table, "The table should exist");
            CollectionAssert.AreEqual(new[] { "id" },
                table.PrimaryKey.Select(c => c.ColumnName).ToArray(),
                "The PK should be configured correctly");

            Assert.IsTrue(db.ContainsConstraint("FK_LogException_ToLogException"));
        }

        [TestMethod]
        public void MultipleUniqueConstraintsOnTheSameColumnShouldWork()
        {
            string script = @"
                CREATE TABLE [dbo].[TBL] 
                (
                    [id]             INT             IDENTITY (1, 1) NOT NULL,
                    [foo]            NVARCHAR (256)  NULL,
                    [bar]            INT             NULL UNIQUE,
	                CONSTRAINT [UC0] UNIQUE (bar),
	                CONSTRAINT [UC1] UNIQUE (bar, foo),
	                CONSTRAINT [UC2] UNIQUE (bar)
                )";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            visitor.Execute(script);

            var table = db.GetTable("TBL");
            Assert.IsTrue(table.GetColumn("bar").Unique, "Column should be unique");
            {
                var row = table.NewRow("1", 1);
                table.AddRow(row);
            }
            {
                var row = table.NewRow("1", 2);
                table.AddRow(row);
            }

            Assert.ThrowsException<ConstraintException>(() =>
            {
                var row = table.NewRow("2", 1);

                table.AddRow(row);
            });
        }

        [TestMethod]
        public void MultipleUniqueConstraintsOnTheSameColumnAsPKShouldWork()
        {
            string script = @"
                CREATE TABLE [dbo].TBL 
                (
                    [id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	                [foo] INT NULL,
	                CONSTRAINT [UC0] UNIQUE (id),
	                CONSTRAINT [UC1] UNIQUE (id, foo)
                )";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            visitor.Execute(script);

            var table = db.GetTable("TBL");
            Assert.IsTrue(table.GetColumn("id").Unique, "Column should be unique");
            CollectionAssert.AreEqual(new[] { table.GetColumn("id") }, table.PrimaryKey,
                "PK should be valid");
            Assert.IsTrue(db.Constraints.OfType<UniqueConstraint>()
                .Where(c => c.Columns.SequenceEqual(new[] { table.GetColumn("id"), table.GetColumn("foo") })).Any(),
                "Composite unique key should exist");
        }

        [TestMethod]
        public void MultiplePKShouldFail()
        {
            string script = @"
                CREATE TABLE [dbo].TBL 
                (
                    [id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	                [foo] INT NULL,
	                CONSTRAINT [UC0] UNIQUE (id),
	                CONSTRAINT [UC1] UNIQUE (id, foo),
	                CONSTRAINT [PK2] PRIMARY KEY (id)
                )";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                visitor.Execute(script);
            });
            Assert.IsNull(db.GetTable("TBL"), "TBL should not exist");
        }

        [TestMethod]
        public void MultipleIdentityShouldFail()
        {
            string script = @"
                CREATE TABLE [dbo].TBL 
                (
                    [id] INT IDENTITY (1, 1) ,
	                [foo] INT IDENTITY (1, 1), 
	                CONSTRAINT [PK2] PRIMARY KEY (id)
                )";
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                /*
               * INFO(Tera): This should fail. SQL Server 2014 throws the following error: 
               * Msg 2744, Level 16, State 2, Line 1
               * Multiple identity columns specified for table 'TBL'. Only one identity column per table is allowed.
               */
                visitor.Execute(script);
            });
            Assert.IsNull(db.GetTable("TBL"), "TBL should not exist");
        }

        [TestMethod]
        public void CreatingAnAlreadyExistingTableShouldFail()
        {
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            string script = @"
                CREATE TABLE [dbo].TBL 
                (
                    [id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	                [foo] INT NULL,
                )";
            visitor.Execute(script);
            Assert.IsNotNull(db.GetTable("TBL"), "TBL should exist");
            Assert.ThrowsException<DuplicateNameException>(() =>
            {
                visitor.Execute(script);
            });
            Assert.IsNotNull(db.GetTable("TBL"), "TBL should still exist");
        }

        [TestMethod]
        public void TestFKDefaultDeleteAndUpdateRules()
        {
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            string script = @"
                CREATE TABLE T1 (Id INT PRIMARY KEY NOT NULL);
                CREATE TABLE T2
                (
                    Id INT PRIMARY KEY IDENTITY NOT NULL,
	                [Name] NVARCHAR(50) NULL,
	                T1 INT NULL,
                    CONSTRAINT [FK_T1_T2] FOREIGN KEY ([T1]) REFERENCES T1 ([Id])
                );
                ";
            visitor.Execute(script);

            var t1 = db.GetTable("T1");
            Assert.IsNotNull(t1, "Table T1 should exist");
            var t2 = db.GetTable("T2");
            Assert.IsNotNull(t2, "Table T2 should exist");

            // Initialize T1
            t1.AddRow(1); t1.AddRow(2); t1.AddRow(3);

            // Initialize T2
            Action<string, int?> t2_insert = (f1, f2) =>
            {
                var row = t2.NewRow(f1, f2);
                t2.AddRow(row);
            };
            t2_insert("A", 1);
            t2_insert("B", 2);
            t2_insert("C", 3);
            t2_insert("D", null);

            Assert.ThrowsException<ConstraintException>(() =>
            {
                t2_insert("E", 4);
            });

            Assert.ThrowsException<ConstraintException>(() =>
            {
                t1.FindRow(1).Delete();
            });

            Assert.ThrowsException<ConstraintException>(() =>
            {
                var row = t1.FindRow(1);
                row["Id"] = 4;
            });
        }

        [TestMethod]
        public void TestFKNoActionDeleteAndUpdateRules()
        {
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            string script = @"
                CREATE TABLE T1 (Id INT PRIMARY KEY NOT NULL);
                CREATE TABLE T2
                (
                    Id INT PRIMARY KEY IDENTITY NOT NULL,
	                [Name] NVARCHAR(50) NULL,
	                T1 INT NULL,
                    CONSTRAINT [FK_T1_T2] FOREIGN KEY ([T1]) REFERENCES T1 ([Id])
	                ON DELETE NO ACTION
	                ON UPDATE NO ACTION
                );
                ";
            visitor.Execute(script);

            var t1 = db.GetTable("T1");
            Assert.IsNotNull(t1, "Table T1 should exist");
            var t2 = db.GetTable("T2");
            Assert.IsNotNull(t2, "Table T2 should exist");

            // Initialize T1
            t1.AddRow(1); t1.AddRow(2); t1.AddRow(3);

            // Initialize T2
            Action<string, int?> t2_insert = (f1, f2) =>
            {
                var row = t2.NewRow(f1, f2);
                t2.AddRow(row);
            };
            t2_insert("A", 1);
            t2_insert("B", 2);
            t2_insert("C", 3);
            t2_insert("D", null);

            Assert.ThrowsException<ConstraintException>(() =>
            {
                t2_insert("E", 4);
            });

            Assert.ThrowsException<ConstraintException>(() =>
            {
                t1.FindRow(1).Delete();
            });

            Assert.ThrowsException<ConstraintException>(() =>
            {
                var row = t1.FindRow(1);
                row["Id"] = 4;
            });
        }

        [TestMethod]
        public void TestFKCascadeDeleteAndUpdateRules()
        {
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            string script = @"
                CREATE TABLE T1 (Id INT PRIMARY KEY NOT NULL);
                CREATE TABLE T2
                (
                    Id INT PRIMARY KEY IDENTITY NOT NULL,
	                [Name] NVARCHAR(50) NULL,
	                T1 INT NULL,
                    CONSTRAINT [FK_T1_T2] FOREIGN KEY ([T1]) REFERENCES T1 ([Id])
	                ON DELETE CASCADE
	                ON UPDATE CASCADE
                );
                ";
            visitor.Execute(script);

            var t1 = db.GetTable("T1");
            Assert.IsNotNull(t1, "Table T1 should exist");
            var t2 = db.GetTable("T2");
            Assert.IsNotNull(t2, "Table T2 should exist");

            // Initialize T1
            t1.AddRow(1); t1.AddRow(2); t1.AddRow(3);

            // Initialize T2
            Action<string, int?> t2_insert = (f1, f2) =>
            {
                var row = t2.NewRow(f1, f2);
                t2.AddRow(row);
            };
            t2_insert("A", 1);
            t2_insert("B", 2);
            t2_insert("C", 3);
            t2_insert("D", null);

            Assert.ThrowsException<ConstraintException>(() =>
            {
                t2_insert("E", 4);
            });

            t1.FindRow(1).Delete();
            Assert.IsNull(t1.FindRow(1), "The parent row should be removed");
            Assert.IsNull(t2.FindRow(1), "The child row should be removed");

            {
                var row = t1.FindRow(2);
                row["Id"] = 4;
            }
            Assert.IsNotNull(t1.FindRow(4), "The parent row should be updated");
            Assert.AreEqual(4, t2.FindRow(2)["T1"], "The child row should be updated");
        }

        [TestMethod]
        public void TestFKSetNullDeleteAndUpdateRules()
        {
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            string script = @"
                CREATE TABLE T1 (Id INT PRIMARY KEY NOT NULL);
                CREATE TABLE T2
                (
                    Id INT PRIMARY KEY IDENTITY NOT NULL,
	                [Name] NVARCHAR(50) NULL,
	                T1 INT NULL,
                    CONSTRAINT [FK_T1_T2] FOREIGN KEY ([T1]) REFERENCES T1 ([Id])
	                ON DELETE SET NULL
	                ON UPDATE SET NULL
                );
                ";
            visitor.Execute(script);

            var t1 = db.GetTable("T1");
            Assert.IsNotNull(t1, "Table T1 should exist");
            var t2 = db.GetTable("T2");
            Assert.IsNotNull(t2, "Table T2 should exist");

            // Initialize T1
            t1.AddRow(1); t1.AddRow(2); t1.AddRow(3);

            // Initialize T2
            Action<string, int?> t2_insert = (f1, f2) =>
            {
                var row = t2.NewRow(f1, f2);
                t2.AddRow(row);
            };
            t2_insert("A", 1);
            t2_insert("B", 2);
            t2_insert("C", 3);
            t2_insert("D", null);

            Assert.ThrowsException<ConstraintException>(() =>
            {
                t2_insert("E", 4);
            });

            t1.FindRow(1).Delete();
            Assert.IsNull(t1.FindRow(1), "The parent row should be removed");
            Assert.IsNotNull(t2.FindRow(1), "The child row should not be removed");
            Assert.AreEqual(null, t2.FindRow(1)["T1"], "The child row FK should be null");

            {
                var row = t1.FindRow(2);
                row["Id"] = 4;
            }
            Assert.IsNotNull(t1.FindRow(4), "The parent row should be updated");
            Assert.AreEqual(null, t2.FindRow(2)["T1"], "The child row FK should be null");
        }

        [TestMethod]
        public void TestFKSetDefaultDeleteAndUpdateRules()
        {
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            string script = @"
                CREATE TABLE T1 (Id INT PRIMARY KEY NOT NULL);
                CREATE TABLE T2
                (
                    Id INT PRIMARY KEY IDENTITY NOT NULL,
	                [Name] NVARCHAR(50) NULL,
	                T1 INT NOT NULL DEFAULT 3,
                    CONSTRAINT [FK_T1_T2] FOREIGN KEY ([T1]) REFERENCES T1 ([Id])
	                ON DELETE SET DEFAULT
	                ON UPDATE SET DEFAULT
                );
                ";
            visitor.Execute(script);

            var t1 = db.GetTable("T1");
            Assert.IsNotNull(t1, "Table T1 should exist");
            var t2 = db.GetTable("T2");
            Assert.IsNotNull(t2, "Table T2 should exist");

            // Initialize T1
            t1.AddRow(1); t1.AddRow(2); t1.AddRow(3);

            // Initialize T2
            Action<string, int?> t2_insert = (f1, f2) =>
            {
                Row row;
                if (f2.HasValue)
                {
                    row = t2.NewRow(f1, f2);
                }
                else
                {
                    row = t2.NewRow(f1);
                }
                t2.AddRow(row);
            };
            t2_insert("A", 1);
            t2_insert("B", 2);
            t2_insert("C", 3);

            t2_insert("D", null);
            Assert.AreEqual(3, t2.FindRow(4)["T1"]);

            Assert.ThrowsException<ConstraintException>(() =>
            {
                t2_insert("E", 4);
            });

            t1.FindRow(1).Delete();
            Assert.IsNull(t1.FindRow(1), "The parent row should be removed");
            Assert.IsNotNull(t2.FindRow(1), "The child row should not be removed");
            Assert.AreEqual(3, t2.FindRow(1)["T1"], "The child row FK should be 3");

            {
                var row = t1.FindRow(2);
                row["Id"] = 4;
            }
            Assert.IsNotNull(t1.FindRow(4), "The parent row should be updated");
            Assert.AreEqual(3, t2.FindRow(2)["T1"], "The child row FK should be 3");
        }

        [TestMethod]
        public void TestFKSetDefaultDeleteAndUpdateRulesWithNullableColumn()
        {
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            string script = @"
                CREATE TABLE T1 (Id INT PRIMARY KEY NOT NULL);
                CREATE TABLE T2
                (
                    Id INT PRIMARY KEY IDENTITY NOT NULL,
	                [Name] NVARCHAR(50) NULL,
	                T1 INT NULL,
                    CONSTRAINT [FK_T1_T2] FOREIGN KEY ([T1]) REFERENCES T1 ([Id])
	                ON DELETE SET DEFAULT
	                ON UPDATE SET DEFAULT
                );
                ";
            visitor.Execute(script);

            var t1 = db.GetTable("T1");
            Assert.IsNotNull(t1, "Table T1 should exist");
            var t2 = db.GetTable("T2");
            Assert.IsNotNull(t2, "Table T2 should exist");

            // Initialize T1
            t1.AddRow(1); t1.AddRow(2); t1.AddRow(3);

            // Initialize T2
            Action<string, int?> t2_insert = (f1, f2) =>
            {
                Row row;
                if (f2.HasValue)
                {
                    row = t2.NewRow(f1, f2);
                }
                else
                {
                    row = t2.NewRow(f1);
                }
                t2.AddRow(row);
            };
            t2_insert("A", 1);
            t2_insert("B", 2);
            t2_insert("C", 3);

            t2_insert("D", null);
            Assert.AreEqual(null, t2.FindRow(4)["T1"]);

            Assert.ThrowsException<ConstraintException>(() =>
            {
                t2_insert("E", 4);
            });

            t1.FindRow(1).Delete();
            Assert.IsNull(t1.FindRow(1), "The parent row should be removed");
            Assert.IsNotNull(t2.FindRow(1), "The child row should not be removed");
            Assert.AreEqual(null, t2.FindRow(1)["T1"], "The child row FK should be null");

            {
                var row = t1.FindRow(2);
                row["Id"] = 4;
            }
            Assert.IsNotNull(t1.FindRow(4), "The parent row should be updated");
            Assert.AreEqual(null, t2.FindRow(2)["T1"], "The child row FK should be null");
        }

        [TestMethod]
        public void TestFKSetNullDeleteRuleWithNotNullColumn()
        {
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            visitor.Execute(@"CREATE TABLE T1 (Id INT PRIMARY KEY NOT NULL);");

            Assert.ThrowsException<ConstraintException>(() =>
            {
                string script = @"
                    CREATE TABLE T2
                    (
                        Id INT PRIMARY KEY IDENTITY NOT NULL,
	                    [Name] NVARCHAR(50) NULL,
	                    T1 INT NOT NULL DEFAULT 3,
                        CONSTRAINT [FK_T1_T2] FOREIGN KEY ([T1]) REFERENCES T1 ([Id])
	                    ON DELETE SET NULL
                    )";
                visitor.Execute(script);
            });
            Assert.IsNull(db.GetTable("T2"), "T2 should not exist");
        }

        [TestMethod]
        public void TestFKSetNullUpdateRuleWithNotNullColumn()
        {
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            visitor.Execute(@"CREATE TABLE T1 (Id INT PRIMARY KEY NOT NULL);");

            Assert.ThrowsException<ConstraintException>(() =>
            {
                string script = @"
                    CREATE TABLE T2
                    (
                        Id INT PRIMARY KEY IDENTITY NOT NULL,
	                    [Name] NVARCHAR(50) NULL,
	                    T1 INT NOT NULL DEFAULT 3,
                        CONSTRAINT [FK_T1_T2] FOREIGN KEY ([T1]) REFERENCES T1 ([Id])
	                    ON UPDATE SET NULL
                    )";
                visitor.Execute(script);
            });
            Assert.IsNull(db.GetTable("T2"), "T2 should not exist");
        }

        [TestMethod]
        public void TestFKSetDefaultDeleteRuleWithNotNullColumn()
        {
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            visitor.Execute(@"CREATE TABLE T1 (Id INT PRIMARY KEY NOT NULL);");

            Assert.ThrowsException<ConstraintException>(() =>
            {
                string script = @"
                    CREATE TABLE T2
                    (
                        Id INT PRIMARY KEY IDENTITY NOT NULL,
	                    [Name] NVARCHAR(50) NULL,
	                    T1 INT NOT NULL,
                        CONSTRAINT [FK_T1_T2] FOREIGN KEY ([T1]) REFERENCES T1 ([Id])
	                    ON DELETE SET DEFAULT
                    )";
                visitor.Execute(script);
            });
            Assert.IsNull(db.GetTable("T2"), "T2 should not exist");
        }

        [TestMethod]
        public void TestFKSetDefaultUpdateRuleWithNotNullColumn()
        {
            var db = new Database();
            var visitor = new SQLInterpreter(db);
            visitor.Execute(@"CREATE TABLE T1 (Id INT PRIMARY KEY NOT NULL);");

            Assert.ThrowsException<ConstraintException>(() =>
            {
                string script = @"
                    CREATE TABLE T2
                    (
                        Id INT PRIMARY KEY IDENTITY NOT NULL,
	                    [Name] NVARCHAR(50) NULL,
	                    T1 INT NOT NULL,
                        CONSTRAINT [FK_T1_T2] FOREIGN KEY ([T1]) REFERENCES T1 ([Id])
	                    ON UPDATE SET DEFAULT
                    )";
                visitor.Execute(script);
            });
            Assert.IsNull(db.GetTable("T2"), "T2 should not exist");
        }
    }
}
