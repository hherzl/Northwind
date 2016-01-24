using System.Data.Entity;
using System.Linq;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Repositories
{
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        public RegionRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public override Region Get(Region entity)
        {
            return DbSet
                .FirstOrDefault(item => item.RegionID == entity.RegionID);
        }
    }
}
