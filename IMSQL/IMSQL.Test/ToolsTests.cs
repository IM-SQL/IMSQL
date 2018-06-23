using IMSQL.Tools;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSQL.Test
{
    [TestClass]
    public class ToolsTests
    {
        private TSqlFragment Parse(string script)
        {
            var parser = new TSql140Parser(false);
            using (var reader = new StringReader(script))
            {
                var result = parser.Parse(reader, out var errors);
                if (errors.Any()) { throw new ParseException(errors); }
                return result;
            }
        }

        [TestMethod]
        public void TestFlattenVisitor()
        {
            var nodeTypes = Parse("SELECT 3")
                .Flatten()
                .Select(each => each.GetType())
                .ToArray();

            Assert.AreEqual(6, nodeTypes.Length);
            CollectionAssert.AreEqual(new[]
            {
                typeof(TSqlScript),
                typeof(TSqlBatch),
                typeof(SelectStatement),
                typeof(QuerySpecification),
                typeof(SelectScalarExpression),
                typeof(IntegerLiteral)
            }, nodeTypes);
        }

        public void TestDynamicVisitor()
        {
            var ast = Parse("SELECT 3 + 4");
            List<int> integers = new List<int>();
            var visitor = SQLDynamicVisitor
                .Default(node => { })
                .ForType<IntegerLiteral>(node => integers.Add(int.Parse(node.Value)));
            visitor.Visit(ast);
            CollectionAssert.AreEqual(new[] { 3, 4 }, integers);
        }
    }
}
