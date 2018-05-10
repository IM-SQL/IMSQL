using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class SQLInterpreter : SQLVisitor
    {
        private Stack<object> stack;
        private DataSet ds;

        public SQLInterpreter(DataSet ds)
        {
            this.ds = ds;
            stack = new Stack<object>();

        }

        public int Execute(string script)
        {
            var parser = new TSql140Parser(false);
            TSqlScript result = (TSqlScript)parser.Parse(new StringReader(script), out var errors);
            foreach (var batch in result.Batches)
            {
                ExplicitVisit(batch);
            }
            return 1;
        }
        private void push(object data) { stack.Push(data); }
        private T pop<T>() { return (T)(stack.Pop()); }


        public override void Visit(CreateTableStatement node)
        {
            //TODO: creation errors? what if the name is taken?
            DataTable t = pop<DataTable>();
            t.TableName = pop<string>();
            ds.Tables.Add(t);
            push(t);
        }

        public override void Visit(SchemaObjectName node)
        {

            //TODO:server, schema, and database identifier may take an important role here.
            push(node.Identifiers[0].Value);
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

        public override void Visit(ColumnDefinition node)
        {
            //TODO: identity, collation,indexes, etc,calcultaed values?
            push(new DataColumn(node.ColumnIdentifier.Value, pop<Type>()));
        }
        public override void Visit(UniqueConstraintDefinition node)
        {
            //I CANNOT CREATE A CONSTRAINT WITH A COLUMN THAT IS NOT ON A TABLE.
            //the table should be at the top of the stack 
            //TODO: constraint name
            DataTable table = pop<DataTable>();
            var constraint = new UniqueConstraint(
                node.Columns.Select(c => table.Columns[c.Column.MultiPartIdentifier[0].Value]).ToArray()
                , node.IsPrimaryKey);
            table.Constraints.Add(constraint);
            push(table);
        }


        public override void Visit(SqlDataTypeReference node)
        {
            switch (node.SqlDataTypeOption)
            {
                case SqlDataTypeOption.Int:
                    push(typeof(int));
                    break;

                case SqlDataTypeOption.Decimal:
                    push(typeof(decimal));
                    break;
                case SqlDataTypeOption.VarChar:
                    //TODO: size limit? unicode limit?
                    push(typeof(string));
                    break;

                case SqlDataTypeOption.Char:
                    //TODO: if this has more than 1 space, it should be a string
                    push(typeof(string));
                    break;
                case SqlDataTypeOption.Bit:
                    push(typeof(bool));
                    break;

                case SqlDataTypeOption.None:

                case SqlDataTypeOption.BigInt:

                case SqlDataTypeOption.SmallInt:

                case SqlDataTypeOption.TinyInt:



                case SqlDataTypeOption.Numeric:

                case SqlDataTypeOption.Money:

                case SqlDataTypeOption.SmallMoney:

                case SqlDataTypeOption.Float:

                case SqlDataTypeOption.Real:

                case SqlDataTypeOption.DateTime:

                case SqlDataTypeOption.SmallDateTime:

                case SqlDataTypeOption.Text:

                case SqlDataTypeOption.NChar:

                case SqlDataTypeOption.NVarChar:

                case SqlDataTypeOption.NText:

                case SqlDataTypeOption.Binary:

                case SqlDataTypeOption.VarBinary:

                case SqlDataTypeOption.Image:

                case SqlDataTypeOption.Cursor:

                case SqlDataTypeOption.Sql_Variant:

                case SqlDataTypeOption.Table:

                case SqlDataTypeOption.Timestamp:

                case SqlDataTypeOption.UniqueIdentifier:

                case SqlDataTypeOption.Date:

                case SqlDataTypeOption.Time:

                case SqlDataTypeOption.DateTime2:

                case SqlDataTypeOption.DateTimeOffset:

                case SqlDataTypeOption.Rowversion:

                default:
                    throw new NotImplementedException();

            }

        }




    }
}
