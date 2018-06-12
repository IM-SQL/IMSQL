using System;
using MemSQL.DataModel.Fields;

namespace MemSQL.DataModel.Fields
{
    internal class IdentityField : Field
    {
        public IdentityField(string columnName, Type dataType, long? identity)
            : base(columnName,dataType,identity)
        { } 
    }
}