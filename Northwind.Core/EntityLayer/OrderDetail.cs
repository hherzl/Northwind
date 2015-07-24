using System;

namespace Northwind.Core.EntityLayer
{
    public class OrderDetail : Object
    {
        public OrderDetail()
        {

        }

        public Int32? OrderID { get; set; }
        
        public Int32? ProductID { get; set; }
        
        public Decimal? UnitPrice { get; set; }
        
        public Int16? Quantity { get; set; }
        
        public Single? Discount { get; set; }

        //public virtual Order FkOrderDetailsOrders { get; set; }

        //public virtual Product FkOrderDetailsProducts { get; set; }
    }
}
