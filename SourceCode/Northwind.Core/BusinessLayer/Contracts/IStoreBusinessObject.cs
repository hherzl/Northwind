using System;
using System.Collections.Generic;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer.Contracts
{
    public interface IStoreBusinessObject : IBusinessObject
    {
        IEnumerable<ProductDetail> SearchProducts(String productName);

        ShoppingCart GetShoppingCart(String customerID);
    }
}
