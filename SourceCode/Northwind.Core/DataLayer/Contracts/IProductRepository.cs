using System;
using System.Collections.Generic;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<ProductDetail> GetDetails(Int32? supplierID, Int32? categoryID, String productName);

        IEnumerable<TenMostExpensiveProduct> GetTenMostExpensiveProducts();
    }
}
