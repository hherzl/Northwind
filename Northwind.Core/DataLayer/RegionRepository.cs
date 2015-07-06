using System.Data.Entity;
using Northwind.Core.DataLayer.Contracts;
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
