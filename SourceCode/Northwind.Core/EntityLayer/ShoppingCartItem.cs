using System;

namespace Northwind.Core.EntityLayer
{
    public class ShoppingCartItem
    {
        public ShoppingCartItem()
        {

        }

        public Int32? ShoppingCartItemID { get; set; }

        public Int32? ProductID { get; set; }

        public String ProductName { get; set; }

        public Int32? Quantity { get; set; }

        public Decimal? UnitPrice { get; set; }

        public Decimal? Total { get; set; }
    }
}
