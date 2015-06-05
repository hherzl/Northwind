using System.Data.Entity;
using System.Linq;
using Northwind.Core.DataLayer.OperationContracts;
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
    }
}
