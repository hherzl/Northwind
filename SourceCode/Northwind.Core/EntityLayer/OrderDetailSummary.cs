using System;

namespace Northwind.Core.EntityLayer
{
    public class OrderDetailSummary
    {
        public OrderDetailSummary()
        {

        }

        public Int32? OrderID { get; set; }

        public Int32? ProductID { get; set; }

        public String ProductName { get; set; }

        public Decimal? UnitPrice { get; set; }

        public Int16? Quantity { get; set; }

        public Decimal Discount { get; set; }

        public Decimal? Total { get; set; }
    }
}
