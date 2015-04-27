using System.Data.Entity;
using Northwind.Core.DataLayer.Operations;
using Northwind.Core.EntityLayer;

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
