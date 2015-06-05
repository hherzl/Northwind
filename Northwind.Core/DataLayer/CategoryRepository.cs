using System.Data.Entity;
using Northwind.Core.DataLayer.OperationContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
