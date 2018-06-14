using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSQL.DataModel.Results;

namespace IMSQL
{
    public class Environment
    {
        private Environment parent;
        protected Environment()
        {
            parent = BaseEnvironment.Value;
        }
        protected Environment(Environment parent)
        {
            this.parent = parent ?? BaseEnvironment.Value;
        }

        public static Environment GlobalEnvironment { get { return BaseEnvironment.Value; } }
        public virtual IResultRow CurrentRow { get; set; }

        public Environment NewChild()
        {
            return new Environment(this);
        }

        private class BaseEnvironment : Environment
        {
            private BaseEnvironment() { }
            private static BaseEnvironment instance;
            static BaseEnvironment()
            {
                instance = new BaseEnvironment();
            }
            public static Environment Value
            {
                get
                {
                    return instance;
                }
            }
            public override IResultRow CurrentRow
            {
                get => base.CurrentRow;
                set => base.CurrentRow = value;
            }
        }
    }

}
