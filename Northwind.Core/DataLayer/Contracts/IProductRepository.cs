using System.Collections.ObjectModel;
using Northwind.Core.PocoLayer;
using Northwind.Core.Practices;

namespace Northwind.Core.DataLayer.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        Collection<ProductDetail> GetDetails();
    }
}
