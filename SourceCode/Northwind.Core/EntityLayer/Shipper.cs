using System;
using System.Collections.ObjectModel;

namespace Northwind.Core.EntityLayer
{
    public class Shipper : Object
    {
        public Shipper()
        {

        }

        public Shipper(Int32? shipperID)
        {
            ShipperID = shipperID;
        }

        public Int32? ShipperID { get; set; }

        public String CompanyName { get; set; }

        public String Phone { get; set; }

        public virtual Collection<Order> Orders { get; set; }
    }
}
