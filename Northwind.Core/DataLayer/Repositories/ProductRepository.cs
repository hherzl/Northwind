using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.Extensions;
using Northwind.Core.PocoLayer;

namespace Northwind.Core.DataLayer.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

        public override IQueryable<Product> GetAll()
        {
            return DbSet;
        }

        public override Product Get(Product entity)
        {
            return DbSet
                .Include(p => p.FkProductsSuppliers)
                .Include(p => p.FkProductsCategories)
                .FirstOrDefault(item => item.ProductID == entity.ProductID);
        }

        public Collection<ProductDetail> GetDetails()
        {
            var query =
                from product in GetAll()
                join category in DbContext.Set<Category>() on product.CategoryID equals category.CategoryID
                join supplier in DbContext.Set<Supplier>() on product.SupplierID equals supplier.SupplierID
                where product.Discontinued == false
                select new ProductDetail()
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    CategoryName = category.CategoryName,
                    CompanyName = supplier.CompanyName,
                    QuantityPerUnit = product.QuantityPerUnit,
                    UnitPrice = product.UnitPrice
                };

            return query.ToCollection();
        }
    }
}
