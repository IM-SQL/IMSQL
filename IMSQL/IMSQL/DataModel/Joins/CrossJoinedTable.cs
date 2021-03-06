﻿using IMSQL.DataModel.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSQL.DataModel.Joins
{
    public class CrossJoinedTable : RecordTable
    {
        protected readonly IResultTable first;
        protected readonly IResultTable second;

        public CrossJoinedTable(IResultTable first, IResultTable second)
            : base()
        {
            this.first = first;
            this.second = second;
            Columns = JoinColumns(first, second);
            Records = JoinRecords(first, second);
        }

        public override int IndexOfColumn(string[] name)
        {
            if (name.Length == 1)
            { return base.IndexOfColumn(name); }
            if (name.Length > 2) { throw new NotImplementedException(); }


            string tblName = name[0];
            string colName = name[1];
            //TODO: if the item1 (name) is null, i should check it anyway, the joins do not have names.
            //Maybe this should return -1 if not found, and i can check everything everytime. Maybe?
            if (first.TableName == tblName)
            {
                return first.IndexOfColumn(new string[] { colName });
            }
            if (second.TableName == tblName)
            {
                return first.Columns.Count() + second.IndexOfColumn(new string[] { colName });
            }
            throw new NotImplementedException("Error here? table not found");
        }
        protected virtual IEnumerable<ResultColumn> JoinColumns(IResultTable first, IResultTable second)
        {
            return first.Columns.Union(second.Columns).ToArray();
        }

        protected virtual IEnumerable<IResultRow> JoinRecords(IResultTable first, IResultTable second)
        {
            //TODO: this behaviour properly
            foreach (var row1 in first.Records)
            {
                foreach (var row2 in second.Records)
                {
                    var row = new Record(
                        row1.ItemArray.Concat(row2.ItemArray).ToArray()
                        , this);
                    yield return row;

                }

            }

        }
    }
}
