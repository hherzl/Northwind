using System;

namespace Northwind.Core.EntityLayer
{
    public class ChangeLog
    {
        public ChangeLog()
        {

        }

        public Int32? ChangeLogID { get; set; }

        public String TableName { get; set; }

        public String ColumnName { get; set; }

        public String Value { get; set; }

        public DateTime? CreationDate { get; set; }

    }
}
