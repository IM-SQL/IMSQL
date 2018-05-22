using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public abstract class SQLBaseInterpreter : SQLVisitor
    {
        protected DataSet ds;

        public SQLBaseInterpreter(DataSet ds)
        {
            this.ds = ds;
        }

        protected override object InternalVisit(MultiPartIdentifier node)
        {
            return node.Identifiers.Select(each => each.Value).ToArray();
        }

        protected override object InternalVisit(ColumnReferenceExpression node)
        {
            //TODO: this and SchemaObject should work differently.
            return Visit<string[]>(node.MultiPartIdentifier).Last();
        }

        protected override object InternalVisit(SchemaObjectName node)
        {
            //TODO:server, schema, and database identifier may take an important role here.
            return node.Identifiers.Last().Value;
        }

        protected override object InternalVisit(SqlDataTypeReference node)
        {
            /*
             * INFO(Richo): Based on the following table
             * https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-data-type-mappings
             */
            switch (node.SqlDataTypeOption)
            {
                case SqlDataTypeOption.Int:
                    return typeof(Int32);

                case SqlDataTypeOption.BigInt:
                    return typeof(Int64);

                case SqlDataTypeOption.SmallInt:
                    return typeof(Int16);

                case SqlDataTypeOption.TinyInt:
                    return typeof(Byte);

                case SqlDataTypeOption.Decimal:
                case SqlDataTypeOption.Numeric:
                case SqlDataTypeOption.Money:
                case SqlDataTypeOption.SmallMoney:
                    return typeof(Decimal);

                case SqlDataTypeOption.Text:
                case SqlDataTypeOption.NChar:
                case SqlDataTypeOption.NVarChar:
                case SqlDataTypeOption.NText:
                case SqlDataTypeOption.VarChar:
                case SqlDataTypeOption.Char:
                    //TODO: size limit? unicode limit?
                    //TODO: if this has more than 1 space, it should be a string
                    return typeof(String);

                case SqlDataTypeOption.Bit:
                    return typeof(Boolean);

                case SqlDataTypeOption.Float:
                    return typeof(Double);

                case SqlDataTypeOption.Real:
                    return typeof(Single);

                case SqlDataTypeOption.Date:
                case SqlDataTypeOption.DateTime:
                case SqlDataTypeOption.DateTime2:
                case SqlDataTypeOption.SmallDateTime:
                    return typeof(DateTime);

                case SqlDataTypeOption.Time:
                    return typeof(TimeSpan);

                case SqlDataTypeOption.DateTimeOffset:
                    return typeof(DateTimeOffset);

                case SqlDataTypeOption.Binary:
                case SqlDataTypeOption.VarBinary:
                case SqlDataTypeOption.Image:
                case SqlDataTypeOption.Rowversion:
                case SqlDataTypeOption.Timestamp:
                    return typeof(Byte[]);

                case SqlDataTypeOption.Sql_Variant:
                    return typeof(Object);

                case SqlDataTypeOption.UniqueIdentifier:
                    return typeof(Guid);

                case SqlDataTypeOption.None:
                case SqlDataTypeOption.Cursor:
                case SqlDataTypeOption.Table:
                default:
                    throw new NotSupportedException();
            }
        }

        protected override object InternalVisit(IntegerLiteral node)
        {
            return new Func<object>(() => { return int.Parse(node.Value); });
        }

        protected override object InternalVisit(StringLiteral node)
        {
            return new Func<object>(() => { return node.Value.ToString(); });
        }

        protected override object InternalVisit(NullLiteral node)
        {
            return new Func<object>(() => { return DBNull.Value; });
        }

        protected override object InternalVisit(NamedTableReference node)
        {
            //TODO: alias?
            var tableName = Visit<string>(node.SchemaObject);
            //TODO: error on table not present?
            return ds.Tables[tableName];
        }

        protected override object InternalVisit(TopRowFilter node)
        {
            return new TopResult((int)Visit<Func<object>>(node.Expression)(), node.Percent, node.WithTies);
        }

        /*INFO(Tera):i believe the expressions should be habdled differently,
         * and should always start a new interpreter from the top of the expression*/
        protected override object InternalVisit(ParenthesisExpression node)
        {
            return new SQLExpressionInterpreter(ds).InternalVisit(node);
        }

        protected override object InternalVisit(WhereClause node)
        {
            //TODO: node.Cursor
            return new SQLExpressionInterpreter(ds).Visit<object>(node);
        }

        protected override object InternalVisit(BooleanBinaryExpression node)
        {
            //TODO: node.Cursor
            return new SQLExpressionInterpreter(ds).Visit<object>(node);
        }

        protected override object InternalVisit(BooleanNotExpression node)
        {
            //TODO: node.Cursor
            return new SQLExpressionInterpreter(ds).Visit<object>(node);
        }
    }
}
