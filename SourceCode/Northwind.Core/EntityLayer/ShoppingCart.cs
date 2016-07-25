using System;
using System.Collections.ObjectModel;

namespace Northwind.Core.EntityLayer
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {

        }

        public ShoppingCart(Int32? shoppingCartID)
        {
            ShoppingCartID = shoppingCartID;
        }

        public Int32? ShoppingCartID { get; set; }

        public String CustomerID { get; set; }

        public DateTime? Date { get; set; }

        public Decimal? Total { get; set; }

        public virtual Collection<ShoppingCartItem> Items { get; set; }
    }
}
