using System.Collections.Generic;
using System.Linq;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.OperationContracts
{
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<ProductDetail> GetDetails();

        IEnumerable<TenMostExpensiveProduct> GetTenMostExpensiveProducts();
    }
}
