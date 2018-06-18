using IMSQL.DataModel.Results;
using System;
namespace IMSQL
{
    public class Selector
    {
        public Selector(string name, Func<IResultRow, object> func) {
            OutputName = name;
            GetValueFrom = func;
        }
        public string OutputName { get; private set; }
        public Func<IResultRow, object> GetValueFrom { get; private set; }
    }
}