using System;
using System.Collections.Generic;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Contracts
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<OrderSummary> GetSummaries(String customerID, Int32? employeeID, Int32? shipperID);
    }
}
