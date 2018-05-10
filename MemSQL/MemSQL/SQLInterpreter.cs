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
            var columns = pop<DataColumn[]>();
            DataTable t = new DataTable(pop<string>());
            t.Columns.AddRange(columns);
            ds.Tables.Add(t);

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
                columns[i] =pop<DataColumn>();
            }
            push(columns);
        }

        public override void Visit(ColumnDefinition node)
        {
            //TODO: identity, collation,indexes, etc,calcultaed values?
            push(new DataColumn(node.ColumnIdentifier.Value, pop<Type>()));
        }


        public override void Visit(SqlDataTypeReference node)
        {
            switch (node.SqlDataTypeOption)
            {
                case SqlDataTypeOption.Int:
                    push(typeof(int));
                    break;

                case SqlDataTypeOption.VarChar:
                    //TODO: size limit? unicode limit?
                    push(typeof(string));
                    break;

                case SqlDataTypeOption.Bit:
                    push(typeof(bool));
                    break;

                case SqlDataTypeOption.None:

                case SqlDataTypeOption.BigInt:

                case SqlDataTypeOption.SmallInt:

                case SqlDataTypeOption.TinyInt:


                case SqlDataTypeOption.Decimal:

                case SqlDataTypeOption.Numeric:

                case SqlDataTypeOption.Money:

                case SqlDataTypeOption.SmallMoney:

                case SqlDataTypeOption.Float:

                case SqlDataTypeOption.Real:

                case SqlDataTypeOption.DateTime:

                case SqlDataTypeOption.SmallDateTime:

                case SqlDataTypeOption.Char:

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
