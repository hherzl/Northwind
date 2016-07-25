using System;
using System.Collections.Generic;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer
{
    public class StoreBusinessObject : IStoreBusinessObject
    {
        protected IStoreUow Uow;

        public StoreBusinessObject(IStoreUow uow)
        {
            Uow = uow;
        }

        public void Release()
        {
            if (Uow != null)
            {
                Uow.Dispose();
            }
        }

        public IEnumerable<ProductDetail> SearchProducts(String productName)
        {
            return Uow.ProductRepository.GetDetails(null, null, productName);
        }

        public ShoppingCart GetShoppingCart(String customerID)
        {
            return Uow.ShoppingCartRepository.Get(new ShoppingCart { });
        }
    }
}
