using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class Environment : IDictionary<string, object>
    {
        private Dictionary<string, object> values;
        private Environment parent;

        public Environment(Environment parent)
        {
            this.parent = parent;
            values = new Dictionary<string, object>();
        }

        public Environment() : this(null) { }
        
        public object this[string key]
        {
            get
            {
                if (values.ContainsKey(key))
                {
                    return values[key];
                }
                else
                {
                    if (parent != null)
                        return parent[key];
                    throw new KeyNotFoundException();
                }
            }
            set
            {
                if (values.ContainsKey(key))
                {
                    values[key] = value;
                }
                else
                {
                    if (parent != null)
                        parent[key] = value;
                    throw new KeyNotFoundException();
                }
            }
        }

        public ICollection<string> Keys => parent == null ? values.Keys : (ICollection<string>)values.Keys.Union(parent.Keys).Distinct();

        public ICollection<object> Values => (ICollection<object>)Keys.Select(k => this[k]);

        public int Count => Keys.Count;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(string key, object value)
        {
            values[key] = value;
        }

        public void Add(KeyValuePair<string, object> item)
        {
            values[item.Key] = item.Value;
        }

        public void Clear()
        {
            values.Clear();
            //parent.Clear();
        }

        internal Environment NewChild()
        {
            return new Environment(this);
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(string key)
        {
            return Keys.Contains(key);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return Keys.Select(k => new KeyValuePair<string, object>(k, this[k])).GetEnumerator();

        }

        public bool Remove(string key)
        {
            return values.Remove(key);
            //parent?
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, out object value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Keys.Select(k => new KeyValuePair<string, object>(k, this[k])).GetEnumerator();
        }

        public T At<T>(string key)
        {
            return (T)this[key];
        }
    }
}
