using System.Data.Entity;
using System.Linq;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public override Category Get(Category entity)
        {
            return DbSet
                .FirstOrDefault(item => item.CategoryID == entity.CategoryID);
        }
    }
}
