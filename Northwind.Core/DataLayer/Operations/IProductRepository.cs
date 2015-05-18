using System.Collections.Generic;
using System.Linq;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Operations
{
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<ProductDetail> GetDetails();

        IEnumerable<TenMostExpensiveProduct> GetTenMostExpensiveProducts();
    }
}
