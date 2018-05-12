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
    /// this class knows how to explicitVisit and Visit the nodes that are used by all the other visitors, for example the literals, data types, and names
    /// </summary>
    public abstract class SQLVisitor : SQLTemporalInterpreter
    {

        protected Stack<object> stack;
        protected DataSet ds;

        public SQLVisitor(DataSet ds)
        {
            this.ds = ds;
            stack = new Stack<object>();
        }
        protected void push(object data) { stack.Push(data); }
        protected T pop<T>() { return (T)(stack.Pop()); }
         
        public override void ExplicitVisit(SchemaObjectName node)
        {
            //not checking the childs for now
            //TODO: check the childs
            Visit(node);
        }

        public override void ExplicitVisit(SqlDataTypeReference node)
        {
            Visit(node);
        }

        public override void ExplicitVisit(IntegerLiteral node)
        {
            Visit(node);
        }

        public override void ExplicitVisit(StringLiteral node)
        {
            Visit(node);
        }

        
        public override void Visit(SchemaObjectName node)
        {
            //TODO:server, schema, and database identifier may take an important role here.
            push(node.Identifiers[0].Value);
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

                case SqlDataTypeOption.DateTime:
                    push(typeof(DateTime));
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

        public override void Visit(IntegerLiteral node)
        {
            push(int.Parse(node.Value));
        }

        public override void Visit(StringLiteral node)
        {
            push(node.Value.ToString());
        }

        public override void ExplicitVisit(NamedTableReference node)
        {
            //TODO: alias?
            node.SchemaObject.Accept(this);
            Visit(node);
        }

        public override void Visit(NamedTableReference node)
        {
            //TODO: error on table not present?
            push(ds.Tables[pop<string>()]);
        }
    }
}
