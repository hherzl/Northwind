using System.Data.Entity;
using System.Linq;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public override Supplier Get(Supplier entity)
        {
            return DbSet
                .FirstOrDefault(item => item.SupplierID == entity.SupplierID);
        }
    }
}
