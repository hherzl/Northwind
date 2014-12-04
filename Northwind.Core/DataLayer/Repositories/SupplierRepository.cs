using System.Data.Entity;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.PocoLayer;

namespace Northwind.Core.DataLayer.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
