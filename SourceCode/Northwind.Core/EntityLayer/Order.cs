using System;
using System.Collections.ObjectModel;

namespace Northwind.Core.EntityLayer
{
    public class Order : Object
    {
        public Order()
        {

        }

        public Order(Int32? orderID)
        {
            OrderID = orderID;
        }

        public Int32? OrderID { get; set; }

        public String CustomerID { get; set; }

        public Int32? EmployeeID { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public Int32? ShipVia { get; set; }

        public Decimal? Freight { get; set; }

        public String ShipName { get; set; }

        public String ShipAddress { get; set; }

        public String ShipCity { get; set; }

        public String ShipRegion { get; set; }

        public String ShipPostalCode { get; set; }

        public String ShipCountry { get; set; }

        public virtual Customer FkOrdersCustomers { get; set; }

        public virtual Employee FkOrdersEmployees { get; set; }

        public virtual Shipper FkOrdersShippers { get; set; }

        public virtual Collection<OrderDetailSummary> OrderSummaries { get; set; }
    }
}
