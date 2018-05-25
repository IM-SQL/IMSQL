using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class ConstraintCollection : IEnumerable<Constraint>
    {
        private List<Constraint> constraints = new List<Constraint>();

        public Constraint this[string name]
        {
            get { return constraints.FirstOrDefault(col => Equals(name, col.ConstraintName)); }
        }

        public int Count { get { return constraints.Count; } }

        public bool Contains(string constraintName)
        {
            return constraints.Any(each => Equals(constraintName, each.ConstraintName));
        }

        public void Add(Constraint constraint)
        {
            constraints.Add(constraint);
        }

        public IEnumerator<Constraint> GetEnumerator()
        {
            return constraints.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
