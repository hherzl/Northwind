using System.Data.Entity;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.PocoLayer;

namespace Northwind.Core.DataLayer.Repositories
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
