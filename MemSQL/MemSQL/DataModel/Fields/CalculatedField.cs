using System; 

namespace MemSQL.DataModel.Fields
{
    internal class CalculatedField : Field
    {
        Row owner;
        Func<Row, object> calculateValue;
        public CalculatedField(string columnName, Type dataType, Func<Row,object> expression, Row owner) : base(columnName, dataType)
        {
            calculateValue = expression;
            this.owner = owner;
        }
        //TODO: Exception type.
        public override object Value { get =>calculateValue(owner);

               set =>throw new NotImplementedException("You cannot assing something to this field");
        }
    }
}