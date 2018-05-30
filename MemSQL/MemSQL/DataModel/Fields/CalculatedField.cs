using System; 

namespace MemSQL.DataModel.Fields
{
    internal class CalculatedField : Field
    {
        Func<object> calculateValue;
        public CalculatedField(string columnName, Type dataType, Func<object> defaultValue) : base(columnName, dataType, defaultValue())
        {
            calculateValue = defaultValue;
        }
        //TODO: Exception type.
        public override object Value { get =>calculateValue(); set =>throw new NotImplementedException("You cannot assing something to this field"); }
    }
}