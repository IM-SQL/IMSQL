using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public abstract class SQLVisitor : SQLTemporalInterpreter
    {

        public override void ExplicitVisit(CreateTableStatement node)
        {
            //node.Definition contains what i need.
            //i can define the visiting order here, or just use the one provided by the implementation of the other visitor
            //ExplicitVisit(node.Definition);
            //ExplicitVisit(node.SchemaObjectName);
            //the order of this bothers me
            node.AcceptChildren(this);

            Visit(node);

        }

        public override void ExplicitVisit(SchemaObjectName node)
        {
            //not checking the childs for now
            //TODO: check the childs
            Visit(node);
        }
        public override void ExplicitVisit(TableDefinition node)
        {

            //TODO: indexes
            foreach (var definition in node.ColumnDefinitions)
            {
                definition.Accept(this);
            }
            Visit(node);
             
            foreach (var constraint in node.TableConstraints)
            {
                constraint.Accept(this);
            }
        }
        public override void ExplicitVisit(ColumnDefinition node)
        {
            //if i dont override this it tries to call visit columndefinitionbase
            //TODO: collation? other childs?
            
            node.DataType.Accept(this);
            Visit(node);
            foreach (var constraint in node.Constraints)
            {
                constraint.Accept(this);

            }
        }
        public override void ExplicitVisit(NullableConstraintDefinition node)
        {
            Visit(node);
        }
        public override void ExplicitVisit(UniqueConstraintDefinition node)
        {
            Visit(node);
        }
        public override void ExplicitVisit(ForeignKeyConstraintDefinition node)
        {
            node.ReferenceTableName.Accept(this);
            Visit(node);
        }

        public override void ExplicitVisit(SqlDataTypeReference node)
        {
            Visit(node);
        }


    }
}
