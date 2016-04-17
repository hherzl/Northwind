using System.Data.Entity;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Repositories
{
    public class CategorySaleFor1997Repository : Repository<CategorySaleFor1997>, ICategorySaleFor1997Repository
    {
        public CategorySaleFor1997Repository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
