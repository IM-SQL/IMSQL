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
    public class SQLInterpreter : SQLTemporalInterpreter
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



        public override void ExplicitVisit(CreateTableStatement node)
        {
            //node.Definition contains what i need.
            //i can define the visiting order here, or just use the one provided by the implementation of the other visitor
            //ExplicitVisit(node.Definition);
            //ExplicitVisit(node.SchemaObjectName);

            node.AcceptChildren(this);

            Visit(node);

        }

        public override void Visit(CreateTableStatement node)
        {

        }




        public override void ExplicitVisit(SchemaObjectName node)
        {
            //not checking the childs for now
            //TODO: check the childs
            Visit(node);
        }

        public override void Visit(SchemaObjectName node)
        {

            //TODO:server, schema, and database identifier may take an important role here.
            stack.Push(node.Identifiers[0].Value);
            base.Visit(node);
        }
        public override void ExplicitVisit(TableDefinition node)
        {
            //TODO: indexes, constraints
            foreach (var item in node.ColumnDefinitions)
            {
                item.Accept(this);
            }
            Visit(node);
        }

        public override void ExplicitVisit(ColumnDefinition node)
        {
            //if i dont override this it tries to call visit columndefinitionbase
            node.DataType.Accept(this);
            Visit(node);
        }
        public override void Visit(ColumnDefinition node) {
            //TODO: identity, collation,indexes, etc,calcultaed values?
            //solution for now, tuple
            stack.Push(node.ColumnIdentifier.Value);
         }
         
    }
}
