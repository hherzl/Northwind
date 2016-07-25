using System;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Contracts
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        ShoppingCart GetByCustomerID(String customerID);
    }
}
