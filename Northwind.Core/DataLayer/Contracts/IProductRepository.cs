using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<ProductDetail> GetDetails(String productName, Int32? supplierID, Int32? categoryID);

        IEnumerable<TenMostExpensiveProduct> GetTenMostExpensiveProducts();
    }
}
