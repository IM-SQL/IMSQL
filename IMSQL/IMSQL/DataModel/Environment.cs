﻿using System;
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
        private IResultRow _currentRow;
        private IResultTable _currentTable;

        protected Environment()
        {
            parent = BaseEnvironment.Value;
        }
        protected Environment(Environment parent)
        {
            this.parent = parent ?? BaseEnvironment.Value;
        }

        public static Environment GlobalEnvironment { get { return BaseEnvironment.Value; } }
        public virtual IResultRow CurrentRow
        {
            get => _currentRow ?? parent.CurrentRow;
            set => _currentRow = value;
        }
        public virtual IResultTable CurrentTable
        {
            get => _currentTable ?? parent.CurrentTable;
            set => _currentTable = value;
        }

        public Environment NewChild()
        {
            return new Environment(this);
        }

        private class BaseEnvironment : Environment
        {
            private BaseEnvironment()
            {
                base.CurrentTable = Table.Empty;
                base.CurrentRow = CurrentTable.Records.First();
            }
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
                //TODO: exception type
                set => throw new NotImplementedException("This should not be possible");
            }
            public override IResultTable CurrentTable
            {
                get => base.CurrentTable;
                set => throw new NotImplementedException("This should not be possible");
            }
        }
    }

}
