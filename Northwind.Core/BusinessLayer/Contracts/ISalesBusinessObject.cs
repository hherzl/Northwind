using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer.Contracts
{
    public interface ISalesBusinessObject : IBusinessObject
    {
        Task<IEnumerable<OrderSummary>> GetOrderSummaries();

        Task<Order> GetOrder(Order entity);

        Task<Order> CreateOrder(Order entity);
    }
}
