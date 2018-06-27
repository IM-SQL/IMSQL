using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSQL.Tools
{
    class AnonymousComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> comparation;
        private readonly Func<T, int> hash;

        public AnonymousComparer(Func<T, T, bool> comparation, Func<T, int> hash = null)
        {
            this.comparation = comparation;
            this.hash = hash ?? new Func<T, int>((o) => o.GetHashCode());
        }
        public bool Equals(T x, T y)
        {
            return comparation(x, y);
        }

        public int GetHashCode(T obj)
        {
            return hash(obj);
        }
    }
}
