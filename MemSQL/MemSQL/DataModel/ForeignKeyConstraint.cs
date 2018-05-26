using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public class ForeignKeyConstraint : Constraint
    {
        public ForeignKeyConstraint(string constraintName, DataColumn[] parents, DataColumn[] children)
            : base(constraintName, children.FirstOrDefault()?.Table)
        {
            Columns = children;
            RelatedColumns = parents;

            RelatedTable = RelatedColumns.FirstOrDefault()?.Table;
        }

        public DataColumn[] Columns { get; }
        public DataColumn[] RelatedColumns { get; }
        public DataTable RelatedTable { get; }
        public Rule DeleteRule { get; set; }
        public Rule UpdateRule { get; set; }

        public override void OnInsert(DataRow row)
        {
            if (!Equals(Table, row.Table)) return;

            for (int i = 0; i < Columns.Length; i++)
            {
                var column = Columns[i];
                var value = row[column.ColumnName];
                if (column.AllowDBNull && (value == null || value == DBNull.Value))
                {
                    continue;
                }

                var relatedColumn = RelatedColumns[i];
                if (!RelatedTable.Rows.Any(relatedRow => Equals(value, relatedRow[relatedColumn.ColumnName])))
                {
                    var msg = string.Format("The INSERT statement conflicted with the FOREIGN KEY constraint '{0}'." +
                        " The conflict occurred in table '{1}', column '{2}'.", 
                        ConstraintName, RelatedTable.TableName, relatedColumn.ColumnName);
                    throw new ConstraintException(msg);
                }
            }
        }

        public override void OnDelete(DataRow relatedRow)
        {
            if (!Equals(RelatedTable, relatedRow.Table)) return;
            
            for (int i = 0; i < RelatedColumns.Length; i++)
            {
                var relatedColumn = RelatedColumns[i];
                var value = relatedRow[relatedColumn.ColumnName];

                var column = Columns[i];
                if (DeleteRule == Rule.None)
                {
                    if (Table.Rows.Any(row => Equals(value, row[column.ColumnName])))
                    {
                        var msg = string.Format("The DELETE statement conflicted with the REFERENCE constraint '{0}'." +
                            " The conflict occurred in table '{1}', column '{2}'.", 
                            ConstraintName, Table.TableName, column.ColumnName);
                        throw new ConstraintException(msg);
                    }
                }
                else if (DeleteRule == Rule.Cascade)
                {
                    foreach (var row in Table.Rows.Where(row => Equals(value, row[column.ColumnName])).ToArray())
                    {
                        row.Delete();
                    }
                }
                else if (DeleteRule == Rule.SetNull)
                {
                    foreach (var row in Table.Rows.Where(row => Equals(value, row[column.ColumnName])).ToArray())
                    {
                        row[column.ColumnName] = DBNull.Value;
                    }
                }
                else if (DeleteRule == Rule.SetDefault)
                {
                    foreach (var row in Table.Rows.Where(row => Equals(value, row[column.ColumnName])).ToArray())
                    {
                        row[column.ColumnName] = column.DefaultValue;
                    }
                }
            }
        }

        public override void OnUpdate(DataRow relatedRow, int columnIndex, object oldValue)
        {
            if (!Equals(RelatedTable, relatedRow.Table)) return;

            var i = columnIndex;
            var relatedColumn = RelatedColumns[i];

            var column = Columns[i];

            if (UpdateRule == Rule.None)
            {
                if (Table.Rows.Any(row => Equals(oldValue, row[column.ColumnName])))
                {
                    var msg = string.Format("The UPDATE statement conflicted with the REFERENCE constraint '{0}'." +
                        " The conflict occurred in table '{1}', column '{2}'.",
                        ConstraintName, Table.TableName, column.ColumnName);
                    throw new ConstraintException(msg);
                }
            }
            else if(UpdateRule == Rule.Cascade)
            {
                foreach (var row in Table.Rows.Where(row => Equals(oldValue, row[column.ColumnName])))
                {
                    row[column.ColumnName] = relatedRow[relatedColumn.ColumnName];
                }
            }
            else if (UpdateRule == Rule.SetNull)
            {
                foreach (var row in Table.Rows.Where(row => Equals(oldValue, row[column.ColumnName])))
                {
                    row[column.ColumnName] = DBNull.Value;
                }
            }
            else if (UpdateRule == Rule.SetDefault)
            {
                foreach (var row in Table.Rows.Where(row => Equals(oldValue, row[column.ColumnName])))
                {
                    row[column.ColumnName] = column.DefaultValue;
                }
            }
        }
    }
}
