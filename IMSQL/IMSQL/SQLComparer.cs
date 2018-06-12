using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSQL
{
    class SQLComparer : IComparer
    {
        public static readonly SQLComparer Default = new SQLComparer();

        //
        // Summary:
        //     Compares two objects and returns a value indicating whether one is less than,
        //     equal to, or greater than the other.
        //
        // Parameters:
        //   x:
        //     The first object to compare.
        //
        //   y:
        //     The second object to compare.
        //
        // Returns:
        //     A signed integer that indicates the relative values of x and y, as shown in the
        //     following table.Value Meaning Less than zero x is less than y. Zero x equals
        //     y. Greater than zero x is greater than y.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     Neither x nor y implements the System.IComparable interface.-or- x and y are
        //     of different types and neither one can handle comparisons with the other.
        public int Compare(object x, object y)
        {
            var comparer = Comparer.DefaultInvariant;

            // Try integer comparison first
            {
                var x_long = NormalizeInteger(x);
                var y_long = NormalizeInteger(y);
                if (x_long != null && y_long != null)
                {
                    return comparer.Compare(x_long, y_long);
                }
            }

            return comparer.Compare(x, y);
        }

        private long? NormalizeInteger(object x)
        {
            Type[] types = new[]
            {
                typeof(bool), typeof(Byte),
                typeof(Int16), typeof(Int32), typeof(Int64)
            };
            if (types.Any(type => type.IsAssignableFrom(x.GetType())))
            {
                return Convert.ToInt64(x);
            }
            else if (x is string && long.TryParse(x.ToString(), out long result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
