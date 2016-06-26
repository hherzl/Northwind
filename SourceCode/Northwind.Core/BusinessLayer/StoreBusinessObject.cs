using System;
using System.Collections.Generic;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.DataLayer.DataContracts;

namespace Northwind.Core.BusinessLayer
{
    public class StoreBusinessObject : IStoreBusinessObject
    {
        protected ISalesUow Uow;

        public StoreBusinessObject(ISalesUow uow)
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

        public IEnumerable<ProductDetail> SearchProducts(Int32? supplierID, Int32? categoryID, String productName)
        {
            return null;
        }
    }
}
