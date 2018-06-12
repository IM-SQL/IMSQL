using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSQL
{
    class TopResult
    {
        public TopResult(int amount) : this(amount, false, false) {}

        public TopResult(int amount, bool percent, bool ties)
        {
            Amount = amount;
            Percent = percent;
            WithTies = ties;
        }

        public int Amount { get; }
        public bool Percent { get; }
        public bool WithTies { get; }
    }
}
