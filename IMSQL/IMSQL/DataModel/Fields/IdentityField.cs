using System;
using IMSQL.DataModel.Fields;

namespace IMSQL.DataModel.Fields
{
    internal class IdentityField : Field
    {
        public IdentityField(string columnName, Type dataType, long? identity)
            : base(columnName,dataType,identity)
        { } 
    }
}