using System.Data.Entity;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer
{
    public class OrderDetailSummaryRepository : Repository<OrderDetailSummary>, IOrderDetailSummaryRepository
    {
        public OrderDetailSummaryRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
