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
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            var result = visitor.Execute(script);
            Assert.AreEqual(0, result.RowsAffected);
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
            var result = visitor.Execute(script);
            Assert.AreEqual(0, result.RowsAffected);
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
        public void DefaultValuesTableCreationTest()
        {
            string script = "Create table [TBL](" +
                "col1 int DEFAULT 3," +
                "col2 varchar(3) DEFAULT 'asd'," +
                "col3 bit DEFAULT 1)";
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            var result = visitor.Execute(script);
            Assert.AreEqual(0, result.RowsAffected);
            Assert.IsTrue(ds.Tables.Contains("TBL"), "The table must be created");
            var table = ds.Tables["TBL"];
            Assert.IsTrue(table.Columns.Contains("col1"));
            Assert.AreEqual(typeof(int), table.Columns["col1"].DataType);
            Assert.IsTrue(table.Columns.Contains("col2"));
            Assert.AreEqual(typeof(string), table.Columns["col2"].DataType);
            Assert.IsTrue(table.Columns.Contains("col3"));
            Assert.AreEqual(typeof(bool), table.Columns["col3"].DataType);

            var dr = table.NewRow();
            Assert.AreEqual(3, dr["col1"], "The default value was not present on the row");
            Assert.AreEqual("asd", dr["col2"], "The default value was not present on the row");
            Assert.AreEqual(true, dr["col3"], "The default value was not present on the row");
        }

        [TestMethod]
        public void NullableTableCreationTest()
        {
            string script = "Create table [TBL](col1 int NOT NULL,col2 int NULL)";
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            var result = visitor.Execute(script);
            Assert.AreEqual(0, result.RowsAffected);
            Assert.IsTrue(ds.Tables.Contains("TBL"), "The table must be created");
            var table = ds.Tables["TBL"];
            Assert.IsTrue(table.Columns.Contains("col1"));
            Assert.AreEqual(typeof(int), table.Columns["col1"].DataType);
            Assert.IsFalse(table.Columns["col1"].AllowDBNull, "This column should not allow nulls");
            Assert.IsTrue(table.Columns.Contains("col2"));
            Assert.AreEqual(typeof(int), table.Columns["col2"].DataType);
            Assert.IsTrue(table.Columns["col2"].AllowDBNull, "This column should allow nulls");
        }

        [TestMethod]
        public void AutoincrementPKTableCreationTest()
        {
            string script = "Create table [TBL](ID int IDENTITY(1,1) PRIMARY KEY, TWICE int IDENTITY(2,2))";
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            var result = visitor.Execute(script);
            Assert.AreEqual(0, result.RowsAffected);
            Assert.IsTrue(ds.Tables.Contains("TBL"), "The table must be created");
            var table = ds.Tables["TBL"];
            Assert.IsTrue(table.Columns.Contains("ID"));
            Assert.AreEqual(typeof(int), table.Columns["ID"].DataType);
            Assert.IsTrue(table.Columns.Contains("TWICE"));
            Assert.AreEqual(typeof(int), table.Columns["TWICE"].DataType);
            Assert.IsTrue(table.PrimaryKey.Length == 1, "The Primary Key is missing!");
            Assert.AreEqual(table.Columns["ID"], table.PrimaryKey[0]);

            for (int i = 1; i < 10; i++)
            {
                var dr = table.NewRow();
                Assert.AreEqual(i, dr["ID"], "The first autonumeric field did not increment");
                Assert.AreEqual(i * 2, dr["TWICE"], "The second autonumeric field did not increment");
            }
        }

        [TestMethod]
        public void InlinePKTableCreationTest()
        {
            string script = "Create table [TBL](ID int PRIMARY KEY)";
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            var result = visitor.Execute(script);
            Assert.AreEqual(0, result.RowsAffected);
            Assert.IsTrue(ds.Tables.Contains("TBL"), "The table must be created");
            var table = ds.Tables["TBL"];
            Assert.IsTrue(table.Columns.Contains("ID"));
            Assert.AreEqual(typeof(int), table.Columns["ID"].DataType);
            Assert.IsTrue(table.PrimaryKey.Length == 1, "The Primary Key is missing!");
            Assert.AreEqual(table.Columns["ID"], table.PrimaryKey[0]);
        }

        [TestMethod]
        public void MultipleInlinedPKConstraintsShouldFail()
        {
            /*
             * INFO(Richo): This should fail. SQL Server 2016 throws the following error:
             * Cannot add multiple PRIMARY KEY constraints to table 'TBL'.
             */
            string script = "Create table [TBL](ID int PRIMARY KEY,ID2 int PRIMARY KEY)";
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                visitor.Execute(script);
            });
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
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            var result = visitor.Execute(script);
            Assert.AreEqual(0, result.RowsAffected);
            Assert.IsTrue(ds.Tables.Contains("TBL"), "The table must be created");
            var table = ds.Tables["TBL"];
            Assert.IsTrue(table.Columns.Contains("ID1"));
            Assert.AreEqual(typeof(int), table.Columns["ID1"].DataType);

            Assert.IsTrue(table.Columns.Contains("ID2"));
            Assert.AreEqual(typeof(int), table.Columns["ID2"].DataType);

            Assert.IsTrue(table.PrimaryKey.Length == 2, "The Primary Key is missing!");
            Assert.AreEqual(table.Columns["ID1"], table.PrimaryKey[0]);
            Assert.AreEqual(table.Columns["ID2"], table.PrimaryKey[1]);
        }

        [TestMethod]
        public void FKCreationTest()
        {
            string script = "Create table [TBL](col1 int NOT NULL,PRIMARY KEY (col1))";
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            var result = visitor.Execute(script);
            Assert.AreEqual(0, result.RowsAffected);
            Assert.IsTrue(ds.Tables.Contains("TBL"), "The table must be created");
            var table = ds.Tables["TBL"];
            Assert.IsTrue(table.Columns.Contains("col1"));
            Assert.AreEqual(typeof(int), table.Columns["col1"].DataType);
            Assert.IsTrue(table.PrimaryKey.Length == 1, "The Primary Key is missing!");
            Assert.AreEqual(table.Columns["col1"], table.PrimaryKey[0]);

            visitor = new SQLInterpreter(ds);
            string script2 = "Create table [TBL2](col2 int NOT NULL,PRIMARY KEY (col2), " +
                "CONSTRAINT FK_tbl FOREIGN KEY (col2)     REFERENCES TBL(col1))";

            result = visitor.Execute(script2);
            Assert.IsTrue(ds.Tables.Contains("TBL2"), "The table must be created");
            var table2 = ds.Tables["TBL2"];
            Assert.IsTrue(table2.Columns.Contains("col2"));
            Assert.AreEqual(typeof(int), table2.Columns["col2"].DataType);
            Assert.IsTrue(table2.PrimaryKey.Length == 1, "The Primary Key is missing!");
            Assert.AreEqual(table2.Columns["col2"], table2.PrimaryKey[0]);


            Assert.IsTrue(table2.Constraints.Count == 2, "Either the PK or the FK are missing");
            Assert.IsTrue(table2.Constraints.Contains("FK_tbl"), "The FK was not found by name");
            var fk = table2.Constraints["FK_tbl"] as ForeignKeyConstraint;
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
            string script = "CREATE TABLE [cTest](  " +
                "[num] INT NOT NULL," +
                "  [calc]  AS" +
                "    CASE WHEN num < 0" +
                "      THEN(num * 2)" +
                "      ELSE(num +2)" +
                "    END)";
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            var result = visitor.Execute(script);
            Assert.AreEqual(0, result.RowsAffected);
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

        [TestMethod]
        public void InvalidSyntaxShouldThrowAnException()
        {
            var script = "create table table (a int)";
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            Assert.ThrowsException<ParseException>(() =>
            {
                visitor.Execute(script);
            });
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
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            Assert.ThrowsException<NullReferenceException>(() =>
            {
                visitor.Execute(script);
            });
        }

        [TestMethod]
        public void FKFromNonExistentColumnShouldFail()
        {
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            {
                string script = "CREATE TABLE [Client] (ID int NOT NULL PRIMARY KEY)";
                visitor.Execute(script);
            }
            {
                var script = @"
                    CREATE TABLE [dbo].[TBL](
	                    [Id] [int] IDENTITY(1,1) NOT NULL,
                        CONSTRAINT [FK_TBL_CLIENT] FOREIGN KEY ([ClientId]) REFERENCES [Client]([Id])
                    )
                    ";
                Assert.ThrowsException<NullReferenceException>(() =>
                {
                    visitor.Execute(script);
                });
            }
        }

        [TestMethod]
        public void FKToNonExistentColumnShouldFail()
        {
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            {
                string script = "CREATE TABLE [Client] (ID2 int NOT NULL PRIMARY KEY)";
                visitor.Execute(script);
            }
            {
                var script = @"
                    CREATE TABLE [dbo].[TBL](
	                    [Id] [int] IDENTITY(1,1) NOT NULL,
                        [ClientId] [int] NOT NULL,
                        CONSTRAINT [FK_TBL_CLIENT] FOREIGN KEY ([ClientId]) REFERENCES [Client]([Id])
                    )
                    ";
                Assert.ThrowsException<NullReferenceException>(() =>
                {
                    visitor.Execute(script);
                });
            }
        }

        [TestMethod]
        public void MultipartTableNamesShouldUseTheLastIdentifier()
        {
            var script = "CREATE TABLE [dbo].[Client] (ID int NOT NULL PRIMARY KEY)";
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            visitor.Execute(script);
            Assert.IsTrue(ds.Tables.Contains("Client"));
        }

        [TestMethod]
        public void IdentityPKWithoutArgsShouldUseDefaultValues()
        {
            string script = @"CREATE TABLE [dbo].[Client] ([Id] INT NOT NULL PRIMARY KEY IDENTITY)";
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            visitor.Execute(script);

            var table = ds.Tables["Client"];
            Assert.IsNotNull(table, "The table should be created");
            var col = table.Columns["Id"];
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
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            visitor.Execute(script);

            var table = ds.Tables["Client"];
            Assert.IsNotNull(table, "The table should be created");
            CollectionAssert.AreEqual(new[] { "Id" },
                table.PrimaryKey.Select(c => c.ColumnName).ToArray(),
                "The PK should be configured correctly");

            string[] cols = new[] { "Id", "Name", "ExternalId", "InternalId" };
            for (int i = 0; i < cols.Length; i++)
            {
                var col = table.Columns[cols[i]];
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
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            visitor.Execute(script);

            var table = ds.Tables["Client"];
            Assert.IsNotNull(table, "The table should be created");
            CollectionAssert.AreEqual(new[] { "Id" },
                table.PrimaryKey.Select(c => c.ColumnName).ToArray(),
                "The PK should be configured correctly");

            string[] cols = new[] { "Id", "Name", "ExternalId", "InternalId" };
            for (int i = 0; i < cols.Length; i++)
            {
                var col = table.Columns[cols[i]];
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
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            visitor.Execute(script);

            var table = ds.Tables["LogException"];
            Assert.IsNotNull(table, "The table should exist");
            CollectionAssert.AreEqual(new[] { "id" },
                table.PrimaryKey.Select(c => c.ColumnName).ToArray(),
                "The PK should be configured correctly");

            Assert.IsTrue(table.Constraints.Contains("FK_LogException_ToLogException"));
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
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            visitor.Execute(script);

            var table = ds.Tables["LogException"];
            Assert.IsNotNull(table, "The table should exist");
            CollectionAssert.AreEqual(new[] { "id" },
                table.PrimaryKey.Select(c => c.ColumnName).ToArray(),
                "The PK should be configured correctly");

            Assert.IsTrue(table.Constraints.Contains("FK_LogException_ToLogException"));
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
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            visitor.Execute(script);

            var table = ds.Tables["TBL"];
            Assert.IsTrue(table.Columns["bar"].Unique, "Column should be unique");

            {
                var row = table.NewRow();
                row["foo"] = "1";
                row["bar"] = 1;
                table.Rows.Add(row);
            }
            {
                var row = table.NewRow();
                row["foo"] = "1";
                row["bar"] = 2;
                table.Rows.Add(row);
            }

            Assert.ThrowsException<ConstraintException>(() =>
            {
                var row = table.NewRow();
                row["foo"] = "2";
                row["bar"] = 1;
                table.Rows.Add(row);
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
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            visitor.Execute(script);

            var table = ds.Tables["TBL"];
            Assert.IsTrue(table.Columns["id"].Unique, "Column should be unique");
            CollectionAssert.AreEqual(new[] { table.Columns["id"] }, table.PrimaryKey,
                "PK should be valid");
            Assert.IsTrue(table.Constraints.OfType<UniqueConstraint>()
                .Where(c => c.Columns.SequenceEqual(new[] { table.Columns["id"], table.Columns["foo"] })).Any(),
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
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                visitor.Execute(script);
            });
        }

        [TestMethod]
        public void CreatingAnAlreadyExistingTableShouldFail()
        {
            DataSet ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            string script = @"
                CREATE TABLE [dbo].TBL 
                (
                    [id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	                [foo] INT NULL,
                )";
            visitor.Execute(script);
            Assert.ThrowsException<DuplicateNameException>(() =>
            {
                visitor.Execute(script);
            });
        }

        [TestMethod]
        public void TestFKDefaultDeleteAndUpdateRules()
        {
            var ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
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

            var t1 = ds.Tables["T1"];
            Assert.IsNotNull(t1, "Table T1 should exist");
            var t2 = ds.Tables["T2"];
            Assert.IsNotNull(t2, "Table T2 should exist");

            // Initialize T1
            t1.Rows.Add(1); t1.Rows.Add(2); t1.Rows.Add(3);

            // Initialize T2
            Action<string, int?> t2_insert = (f1, f2) =>
            {
                var row = t2.NewRow();
                row["Name"] = f1;
                row["T1"] = (object)f2 ?? DBNull.Value;
                t2.Rows.Add(row);
            };
            t2_insert("A", 1);
            t2_insert("B", 2);
            t2_insert("C", 3);
            t2_insert("D", null);

            Assert.ThrowsException<InvalidConstraintException>(() =>
            {
                t2_insert("E", 4);
            });

            Assert.ThrowsException<InvalidConstraintException>(() =>
            {
                t1.Rows.Find(1).Delete();
            });

            Assert.ThrowsException<InvalidConstraintException>(() =>
            {
                var row = t1.Rows.Find(1);
                row["Id"] = 4;
            });
        }

        [TestMethod]
        public void TestFKNoActionDeleteAndUpdateRules()
        {
            var ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
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

            var t1 = ds.Tables["T1"];
            Assert.IsNotNull(t1, "Table T1 should exist");
            var t2 = ds.Tables["T2"];
            Assert.IsNotNull(t2, "Table T2 should exist");

            // Initialize T1
            t1.Rows.Add(1); t1.Rows.Add(2); t1.Rows.Add(3);

            // Initialize T2
            Action<string, int?> t2_insert = (f1, f2) =>
            {
                var row = t2.NewRow();
                row["Name"] = f1;
                row["T1"] = (object)f2 ?? DBNull.Value;
                t2.Rows.Add(row);
            };
            t2_insert("A", 1);
            t2_insert("B", 2);
            t2_insert("C", 3);
            t2_insert("D", null);

            Assert.ThrowsException<InvalidConstraintException>(() =>
            {
                t2_insert("E", 4);
            });

            Assert.ThrowsException<InvalidConstraintException>(() =>
            {
                t1.Rows.Find(1).Delete();
            });

            Assert.ThrowsException<InvalidConstraintException>(() =>
            {
                var row = t1.Rows.Find(1);
                row["Id"] = 4;
            });
        }

        [TestMethod]
        public void TestFKCascadeDeleteAndUpdateRules()
        {
            var ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
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

            var t1 = ds.Tables["T1"];
            Assert.IsNotNull(t1, "Table T1 should exist");
            var t2 = ds.Tables["T2"];
            Assert.IsNotNull(t2, "Table T2 should exist");

            // Initialize T1
            t1.Rows.Add(1); t1.Rows.Add(2); t1.Rows.Add(3);

            // Initialize T2
            Action<string, int?> t2_insert = (f1, f2) =>
            {
                var row = t2.NewRow();
                row["Name"] = f1;
                row["T1"] = (object)f2 ?? DBNull.Value;
                t2.Rows.Add(row);
            };
            t2_insert("A", 1);
            t2_insert("B", 2);
            t2_insert("C", 3);
            t2_insert("D", null);

            Assert.ThrowsException<InvalidConstraintException>(() =>
            {
                t2_insert("E", 4);
            });

            t1.Rows.Find(1).Delete();
            Assert.IsNull(t1.Rows.Find(1), "The parent row should be removed");
            Assert.IsNull(t2.Rows.Find(1), "The child row should be removed");

            {
                var row = t1.Rows.Find(2);
                row["Id"] = 4;
            }
            Assert.IsNotNull(t1.Rows.Find(4), "The parent row should be updated");
            Assert.AreEqual(4, t2.Rows.Find(2)["T1"], "The child row should be updated");
        }

        [TestMethod]
        public void TestFKSetNullDeleteAndUpdateRules()
        {
            var ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
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

            var t1 = ds.Tables["T1"];
            Assert.IsNotNull(t1, "Table T1 should exist");
            var t2 = ds.Tables["T2"];
            Assert.IsNotNull(t2, "Table T2 should exist");

            // Initialize T1
            t1.Rows.Add(1); t1.Rows.Add(2); t1.Rows.Add(3);

            // Initialize T2
            Action<string, int?> t2_insert = (f1, f2) =>
            {
                var row = t2.NewRow();
                row["Name"] = f1;
                row["T1"] = (object)f2 ?? DBNull.Value;
                t2.Rows.Add(row);
            };
            t2_insert("A", 1);
            t2_insert("B", 2);
            t2_insert("C", 3);
            t2_insert("D", null);

            Assert.ThrowsException<InvalidConstraintException>(() =>
            {
                t2_insert("E", 4);
            });

            t1.Rows.Find(1).Delete();
            Assert.IsNull(t1.Rows.Find(1), "The parent row should be removed");
            Assert.IsNotNull(t2.Rows.Find(1), "The child row should not be removed");
            Assert.AreEqual(DBNull.Value, t2.Rows.Find(1)["T1"], "The child row FK should be null");

            {
                var row = t1.Rows.Find(2);
                row["Id"] = 4;
            }
            Assert.IsNotNull(t1.Rows.Find(4), "The parent row should be updated");
            Assert.AreEqual(DBNull.Value, t2.Rows.Find(2)["T1"], "The child row FK should be null");
        }

        [TestMethod]
        public void TestFKSetDefaultDeleteAndUpdateRules()
        {
            var ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
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

            var t1 = ds.Tables["T1"];
            Assert.IsNotNull(t1, "Table T1 should exist");
            var t2 = ds.Tables["T2"];
            Assert.IsNotNull(t2, "Table T2 should exist");

            // Initialize T1
            t1.Rows.Add(1); t1.Rows.Add(2); t1.Rows.Add(3);

            // Initialize T2
            Action<string, int?> t2_insert = (f1, f2) =>
            {
                var row = t2.NewRow();
                row["Name"] = f1;
                if (f2.HasValue) { row["T1"] = f2; }
                t2.Rows.Add(row);
            };
            t2_insert("A", 1);
            t2_insert("B", 2);
            t2_insert("C", 3);

            t2_insert("D", null);
            Assert.AreEqual(3, t2.Rows.Find(4)["T1"]);

            Assert.ThrowsException<InvalidConstraintException>(() =>
            {
                t2_insert("E", 4);
            });

            t1.Rows.Find(1).Delete();
            Assert.IsNull(t1.Rows.Find(1), "The parent row should be removed");
            Assert.IsNotNull(t2.Rows.Find(1), "The child row should not be removed");
            Assert.AreEqual(3, t2.Rows.Find(1)["T1"], "The child row FK should be 3");

            {
                var row = t1.Rows.Find(2);
                row["Id"] = 4;
            }
            Assert.IsNotNull(t1.Rows.Find(4), "The parent row should be updated");
            Assert.AreEqual(3, t2.Rows.Find(2)["T1"], "The child row FK should be 3");
        }

        [TestMethod]
        public void TestFKSetDefaultDeleteAndUpdateRulesWithNullableColumn()
        {
            var ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
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

            var t1 = ds.Tables["T1"];
            Assert.IsNotNull(t1, "Table T1 should exist");
            var t2 = ds.Tables["T2"];
            Assert.IsNotNull(t2, "Table T2 should exist");

            // Initialize T1
            t1.Rows.Add(1); t1.Rows.Add(2); t1.Rows.Add(3);

            // Initialize T2
            Action<string, int?> t2_insert = (f1, f2) =>
            {
                var row = t2.NewRow();
                row["Name"] = f1;
                if (f2.HasValue) { row["T1"] = f2; }
                t2.Rows.Add(row);
            };
            t2_insert("A", 1);
            t2_insert("B", 2);
            t2_insert("C", 3);

            t2_insert("D", null);
            Assert.AreEqual(DBNull.Value, t2.Rows.Find(4)["T1"]);

            Assert.ThrowsException<InvalidConstraintException>(() =>
            {
                t2_insert("E", 4);
            });

            t1.Rows.Find(1).Delete();
            Assert.IsNull(t1.Rows.Find(1), "The parent row should be removed");
            Assert.IsNotNull(t2.Rows.Find(1), "The child row should not be removed");
            Assert.AreEqual(DBNull.Value, t2.Rows.Find(1)["T1"], "The child row FK should be null");

            {
                var row = t1.Rows.Find(2);
                row["Id"] = 4;
            }
            Assert.IsNotNull(t1.Rows.Find(4), "The parent row should be updated");
            Assert.AreEqual(DBNull.Value, t2.Rows.Find(2)["T1"], "The child row FK should be null");
        }

        [TestMethod]
        public void TestFKSetNullDeleteRuleWithNotNullColumn()
        {
            var ds = new DataSet();
            var visitor = new SQLInterpreter(ds);            
            visitor.Execute(@"CREATE TABLE T1 (Id INT PRIMARY KEY NOT NULL);");

            Assert.ThrowsException<InvalidConstraintException>(() =>
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
        }

        [TestMethod]
        public void TestFKSetNullUpdateRuleWithNotNullColumn()
        {
            var ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            visitor.Execute(@"CREATE TABLE T1 (Id INT PRIMARY KEY NOT NULL);");

            Assert.ThrowsException<InvalidConstraintException>(() =>
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
        }

        [TestMethod]
        public void TestFKSetDefaultDeleteRuleWithNotNullColumn()
        {
            var ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            visitor.Execute(@"CREATE TABLE T1 (Id INT PRIMARY KEY NOT NULL);");

            Assert.ThrowsException<InvalidConstraintException>(() =>
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
        }

        [TestMethod]
        public void TestFKSetDefaultUpdateRuleWithNotNullColumn()
        {
            var ds = new DataSet();
            var visitor = new SQLInterpreter(ds);
            visitor.Execute(@"CREATE TABLE T1 (Id INT PRIMARY KEY NOT NULL);");

            Assert.ThrowsException<InvalidConstraintException>(() =>
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
        }
    }
}
