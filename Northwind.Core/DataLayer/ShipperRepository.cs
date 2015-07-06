using System.Data.Entity;
using System.Linq;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer
{
    public class ShipperRepository : Repository<Shipper>, IShipperRepository
    {
        public ShipperRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public override Shipper Get(Shipper entity)
        {
            return DbSet
                .FirstOrDefault(item => item.ShipperID == entity.ShipperID);
        }

        public override System.Threading.Tasks.Task<Shipper> GetAsync(Shipper entity)
        {
            return DbSet
                .FirstOrDefaultAsync(item => item.ShipperID == entity.ShipperID);
        }
    }
}
