using System;
using System.Linq;
using System.Threading.Tasks;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.OperationContracts
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> Get(Int32? orderID);

        IQueryable<OrderSummary> GetSummaries();
    }
}
