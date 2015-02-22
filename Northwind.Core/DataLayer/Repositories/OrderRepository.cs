using System.Data.Entity;
using System.Linq;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.PocoLayer;

namespace Northwind.Core.DataLayer.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public override Order Get(Order entity)
        {
            return DbSet
                .Include(p => p.OrderDetails.Select(od => od.FkOrderDetailsProducts))
                .FirstOrDefault(item => item.OrderID == entity.OrderID);
        }
    }
}
