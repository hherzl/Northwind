using System.Data.Entity;
using Northwind.Core.DataLayer.OperationContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer
{
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        public RegionRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
