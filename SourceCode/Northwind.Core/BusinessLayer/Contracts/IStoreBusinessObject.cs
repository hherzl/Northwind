using System;
using System.Collections.Generic;
using Northwind.Core.DataLayer.DataContracts;

namespace Northwind.Core.BusinessLayer.Contracts
{
    public interface IStoreBusinessObject : IBusinessObject
    {
        IEnumerable<ProductDetail> SearchProducts(Int32? supplierID, Int32? categoryID, String productName);
    }
}
