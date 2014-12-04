using System;
using System.Collections.ObjectModel;
using Northwind.Core.PocoLayer;
using Northwind.Core.Practices;

namespace Northwind.Core.DataLayer.Contracts
{
    public interface IOrderRepository : IRepository<Order>
    {
        
    }
}
