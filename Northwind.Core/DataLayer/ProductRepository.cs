using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.DataLayer.OperationContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<ProductDetail> GetDetails()
        {
            return from product in GetAll()
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
        }

        public IEnumerable<TenMostExpensiveProduct> GetTenMostExpensiveProducts()
        {
            return DbContext
                .Database
                .SqlQuery<TenMostExpensiveProduct>(" exec [Ten Most Expensive Products] ");
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

        public override void Add(Product entity)
        {
            if (!entity.Discontinued.HasValue)
            {
                entity.Discontinued = false;
            }

            base.Add(entity);
        }
    }
}
