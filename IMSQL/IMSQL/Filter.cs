using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSQL.DataModel.Results;
using IMSQL.Tools;

namespace IMSQL
{
    static class Filter
    {
        public static IEnumerable<T> From<T>(IEnumerable<T> source, Func<T, bool> predicate, TopResult topResult = null)
        {
            if (topResult == null)
            {
                foreach (var item in source)
                {
                    if (predicate(item))
                    {
                        yield return item;
                    }
                }
            }
            else
            {
                double top  = topResult.Amount;
                if (topResult.Percent)
                {
                    int size = source.Count();
                    top = top * size / 100;
                    top = Math.Round(top);
                } 
                int returned = 0;
                foreach (var item in source)
                {
                    if (returned >= top) break;

                    if (predicate(item))
                    {
                        returned++;
                        yield return item;
                    }
                }
            }
        }

        internal static IEnumerable<IResultRow> Distinct (IEnumerable<IResultRow> records)
        {
            return records.Distinct(new AnonymousComparer<IResultRow>(
                            (x, y) => x.ItemArray.SequenceEqual(y.ItemArray),
                            (x) => x.ItemArray.GetSequenceHash() //distinct actually uses hash to compare.
                            ));
            
        }
    }
}
