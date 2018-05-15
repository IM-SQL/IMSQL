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

        public override void ExplicitVisit(NullLiteral node)
        {
            Visit(node);
        }
        public override void Visit(SchemaObjectName node)
        {
            //TODO:server, schema, and database identifier may take an important role here.
            push(node.Identifiers.Last().Value);
        }

        public override void Visit(SqlDataTypeReference node)
        {
            /*
             * INFO(Richo): Based on the following table
             * https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-data-type-mappings
             */
            switch (node.SqlDataTypeOption)
            {
                case SqlDataTypeOption.Int:
                    push(typeof(Int32));
                    break;

                case SqlDataTypeOption.BigInt:
                    push(typeof(Int64));
                    break;

                case SqlDataTypeOption.SmallInt:
                    push(typeof(Int16));
                    break;

                case SqlDataTypeOption.TinyInt:
                    push(typeof(Byte));
                    break;

                case SqlDataTypeOption.Decimal:
                case SqlDataTypeOption.Numeric:
                case SqlDataTypeOption.Money:
                case SqlDataTypeOption.SmallMoney:
                    push(typeof(Decimal));
                    break;

                case SqlDataTypeOption.Text:
                case SqlDataTypeOption.NChar:
                case SqlDataTypeOption.NVarChar:
                case SqlDataTypeOption.NText:
                case SqlDataTypeOption.VarChar:
                case SqlDataTypeOption.Char:
                    //TODO: size limit? unicode limit?
                    //TODO: if this has more than 1 space, it should be a string
                    push(typeof(String));
                    break;

                case SqlDataTypeOption.Bit:
                    push(typeof(Boolean));
                    break;

                case SqlDataTypeOption.Float:
                    push(typeof(Double));
                    break;

                case SqlDataTypeOption.Real:
                    push(typeof(Single));
                    break;
                    
                case SqlDataTypeOption.Date:
                case SqlDataTypeOption.DateTime:
                case SqlDataTypeOption.DateTime2:
                case SqlDataTypeOption.SmallDateTime:
                    push(typeof(DateTime));
                    break;
                    
                case SqlDataTypeOption.Time:
                    push(typeof(TimeSpan));
                    break;

                case SqlDataTypeOption.DateTimeOffset:
                    push(typeof(DateTimeOffset));
                    break;

                case SqlDataTypeOption.Binary:
                case SqlDataTypeOption.VarBinary:
                case SqlDataTypeOption.Image:
                case SqlDataTypeOption.Rowversion:
                case SqlDataTypeOption.Timestamp:
                    push(typeof(Byte[]));
                    break;

                case SqlDataTypeOption.Sql_Variant:
                    push(typeof(Object));
                    break;

                case SqlDataTypeOption.UniqueIdentifier:
                    push(typeof(Guid));
                    break;

                case SqlDataTypeOption.None:
                case SqlDataTypeOption.Cursor:
                case SqlDataTypeOption.Table:
                default:
                    throw new NotSupportedException();
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
        public override void Visit(NullLiteral node)
        {
            push(DBNull.Value);
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
