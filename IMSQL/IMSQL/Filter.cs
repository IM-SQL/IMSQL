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
        public static IEnumerable<T> Top<T>(IEnumerable<T> source, TopResult topResult)
        {
            double top = topResult.Amount;
            if (topResult.Percent)
            {
                //TODO: if source is infinite, this will freeze
                int size = source.Count();
                top = top * size / 100;
                top = Math.Round(top);
            }
            int returned = 0;
            foreach (var item in source)
            {
                if (returned >= top) break;
                returned++;
                yield return item;
            }
        }
        public static IEnumerable<T> Where<T>(IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        internal static IEnumerable<T> From<T>(IEnumerable<T> rows, Func<T, bool> predicate, TopResult top)
        {
            var result = Where(rows, predicate);
            if (top != null) {
                result = Top(result, top);
            }
            return result;
        }

        public static IEnumerable<IResultRow> Distinct(IEnumerable<IResultRow> records)
        {
            return records.Distinct(new AnonymousComparer<IResultRow>(
                            (x, y) => x.ItemArray.SequenceEqual(y.ItemArray),
                            (x) => x.ItemArray.GetSequenceHash() //distinct actually uses hash to compare.
                            ));
        }
    }
}
