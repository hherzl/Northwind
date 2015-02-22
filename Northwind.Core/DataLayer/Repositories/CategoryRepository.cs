using System.Data.Entity;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.PocoLayer;

namespace Northwind.Core.DataLayer.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
