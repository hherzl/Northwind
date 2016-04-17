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

        public String CustomerID { get; set; }

        public String CustomerName { get; set; }

        public Int32? EmployeeID { get; set; }

        public String EmployeeName { get; set; }

        public Int32? ShipperID { get; set; }

        public String ShipperName { get; set; }

        public Int32 Lines { get; set; }

        public Decimal? Total { get; set; }
    }
}
