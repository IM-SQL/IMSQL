using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    static class Filter
    {
        public static IEnumerable<T> From<T>(IEnumerable<T> Source, Func<T, bool> Predicate, TopResult Top = null)
        {
            if (Top == null)
            {
                foreach (var item in Source)
                {
                    if (Predicate(item))
                    { yield return item; }
                }
            }
            else
            {
                double top  = Top.Amount;
                if (Top.Percent)
                {
                    int size = Source.Count();
                    top = top * size / 100;
                    top = Math.Round(top);
                } 
                int returned = 0;
                foreach (var item in Source)
                {
                    if (returned >= top)
                        break;
                    if (Predicate(item))
                    {
                        returned++;
                        yield return item;
                    }
                }
            }
        }
    }
}
