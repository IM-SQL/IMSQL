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
            //i am checking the constraints after adding it to the dataset, because some of them cannot be applied otherwise
            foreach (var constraint in node.Definition.TableConstraints)
            {
                constraint.Accept(this);
            }
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

        }
        public override void ExplicitVisit(ColumnDefinition node)
        {
            //if i dont override this it tries to call visit columndefinitionbase
            //TODO: collation? other childs?

            node.DataType.Accept(this);
            Visit(node);
            node.DefaultConstraint?.Accept(this);
            foreach (var constraint in node.Constraints)
            {
                constraint.Accept(this);

            }
        }
        public override void ExplicitVisit(DefaultConstraintDefinition node)
        {//TODO: i think if the default value is a function this might have to be reviewed
            ExplicitVisit(node.Expression);
            Visit(node);
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
        public override void ExplicitVisit(ScalarExpression node)
        {
            node.Accept(this);
        }
        public override void ExplicitVisit(IntegerLiteral node)
        {
            Visit(node);
        }
        public override void ExplicitVisit(StringLiteral node)
        {
            Visit(node);
        }

    }
}
