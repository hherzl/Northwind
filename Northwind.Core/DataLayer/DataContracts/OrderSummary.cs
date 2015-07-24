using System;

namespace Northwind.Core.DataLayer.DataContracts
{
    public class OrderSummary
    {
        public OrderSummary()
        {

        }

        public Int32? OrderID { get; set; }

        public DateTime? OrderDate { get; set; }

        public String Customer { get; set; }

        public String Employee { get; set; }

        public String Shipper { get; set; }

        public Int32 Lines { get; set; }

        public Decimal? Total { get; set; }
    }
}
