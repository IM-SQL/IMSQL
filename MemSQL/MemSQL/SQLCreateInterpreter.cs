using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    /// <summary>
    /// this class implements the methods necesary to execute a create table statement
    /// </summary>
    internal class SQLCreateInterpreter : SQLVisitor
    {
        List<DataColumn> inlinedPKFound;
        List<DataColumn> inlinedUniqueFound;

        public SQLCreateInterpreter(DataSet ds) : base(ds)
        {
            inlinedPKFound = new List<DataColumn>();
            inlinedUniqueFound = new List<DataColumn>();
        }

        public override void ExplicitVisit(CreateTableStatement node)
        {
            //node.Definition contains what i need.
            //i can define the visiting order here, or just use the one provided by the implementation of the other visitor
            //ExplicitVisit(node.Definition);
            //ExplicitVisit(node.SchemaObjectName);
            //the order of this bothers me
            node.AcceptChildren(this);

            Visit(node);
            //i am checking the constraints after adding it to the dataset, because some of them cannot be applied otherwise
            foreach (var constraint in node.Definition.TableConstraints)
            {
                constraint.Accept(this);
            }
        }

        public override void Visit(CreateTableStatement node)
        {
            //TODO: creation errors? what if the name is taken?
            DataTable t = pop<DataTable>();
            t.TableName = pop<string>();
            ds.Tables.Add(t);

            createUniqueConstraint(t, inlinedPKFound.ToArray(), true);
            createUniqueConstraint(t, inlinedUniqueFound.ToArray(), false);
            push(t);
        }

        public override void ExplicitVisit(TableDefinition node)
        {
            //TODO: indexes
            foreach (var definition in node.ColumnDefinitions)
            {
                definition.Accept(this);
            }
            Visit(node);
        }

        public override void Visit(TableDefinition node)
        {
            DataColumn[] columns = new DataColumn[node.ColumnDefinitions.Count];
            for (int i = node.ColumnDefinitions.Count - 1; i >= 0; i--)
            {
                columns[i] = pop<DataColumn>();
            }
            var result = new DataTable();
            result.Columns.AddRange(columns);

            push(result);
        }

        public override void ExplicitVisit(ColumnDefinition node)
        {
            //if i dont override this it tries to call visit columndefinitionbase
            //TODO: collation? other childs?

            node.DataType.Accept(this);
            Visit(node);
            node.DefaultConstraint?.Accept(this);
            node.IdentityOptions?.Accept(this);
            foreach (var constraint in node.Constraints)
            {
                constraint.Accept(this);

            }
        }

        public override void Visit(ColumnDefinition node)
        {
            //TODO: identity, collation,indexes, etc,calcultaed values?
            push(new DataColumn(node.ColumnIdentifier.Value, pop<Type>()));
        }

        public override void ExplicitVisit(IdentityOptions node)
        {
            node.AcceptChildren(this);
            Visit(node);
        }

        public override void Visit(IdentityOptions node)
        {
            int step = pop<int>();
            int seed = pop<int>();
            DataColumn column = pop<DataColumn>();
            column.AutoIncrement = true;
            column.AutoIncrementSeed = seed;
            column.AutoIncrementStep = step;
            push(column);
        }

        public override void ExplicitVisit(DefaultConstraintDefinition node)
        {
            //TODO: i think if the default value is a function this might have to be reviewed
            node.Expression.Accept(this);
            Visit(node);
        }

        public override void Visit(DefaultConstraintDefinition node)
        {
            object value = pop<object>();
            DataColumn col = pop<DataColumn>();
            col.DefaultValue = value;
            push(col);
        }

        public override void ExplicitVisit(NullableConstraintDefinition node)
        {
            Visit(node);
        }

        public override void Visit(NullableConstraintDefinition node)
        {
            //the column should be at the top of the stack.
            DataColumn col = pop<DataColumn>();
            col.AllowDBNull = node.Nullable;
            push(col);
        }

        public override void ExplicitVisit(UniqueConstraintDefinition node)
        {
            Visit(node);
        }

        public override void Visit(UniqueConstraintDefinition node)
        {

            //IF i reach this point and node.columns is empty, then it is not a table level constraint, but a field constraint.
            if (node.Columns.Count == 0)
            {
                DataColumn created = pop<DataColumn>();
                if (node.IsPrimaryKey)
                    inlinedPKFound.Add(created);
                else
                    inlinedUniqueFound.Add(created);
                push(created);
            }
            else
            {

                //I CANNOT CREATE A CONSTRAINT WITH A COLUMN THAT IS NOT ON A TABLE.
                //the table should be at the top of the stack 
                DataTable table = pop<DataTable>();
                createUniqueConstraint(table,
                node.Columns.Select(c => table.Columns[c.Column.MultiPartIdentifier[0].Value]).ToArray()
                , node.IsPrimaryKey, node.ConstraintIdentifier?.Value);


                push(table);
            }
        }

        public override void ExplicitVisit(ForeignKeyConstraintDefinition node)
        {
            node.ReferenceTableName.Accept(this);
            Visit(node);
        }

        public override void Visit(ForeignKeyConstraintDefinition node)
        {
            string referencedTableName = pop<string>();
            var refTable = ds.Tables[referencedTableName];
            var currentTable = pop<DataTable>();

            DataColumn[] parents = node.ReferencedTableColumns.Select(c => refTable.Columns[c.Value]).ToArray();
            DataColumn[] childs = node.Columns.Select(c => currentTable.Columns[c.Value]).ToArray();
            //TODO:CANNOT CREATE A FK WITHOUT ADDING THE TABLE TO THE DATASET FIRST
            ForeignKeyConstraint fk = new ForeignKeyConstraint(node.ConstraintIdentifier.Value, parents, childs);
            currentTable.Constraints.Add(fk);

            push(currentTable);
        }

        private void createUniqueConstraint(DataTable table, DataColumn[] columns, bool isPK, string name = null)
        {
            if (columns.Length > 0)
            {
                var constraint = new UniqueConstraint(name != null ? name :
                    (isPK ? "PrimaryKeyConstraint_" : "UniqueConstraint_")
                    + table.TableName, columns, isPK);
                table.Constraints.Add(constraint);
            }
        }

    }
}
