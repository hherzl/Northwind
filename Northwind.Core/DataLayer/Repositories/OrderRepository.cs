using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public IEnumerable<OrderSummary> GetSummaries()
        {
            return from order in DbCtx.Set<Order>()
                   join customer in DbCtx.Set<Customer>() on order.CustomerID equals customer.CustomerID
                   join employee in DbCtx.Set<Employee>() on order.EmployeeID equals employee.EmployeeID
                   join shipper in DbCtx.Set<Shipper>() on order.ShipVia equals shipper.ShipperID
                   select new OrderSummary()
                   {
                       OrderID = order.OrderID,
                       OrderDate = order.OrderDate,
                       Customer = customer.CompanyName,
                       Employee = employee.FirstName + " " + employee.LastName,
                       Shipper = shipper.CompanyName,
                       Lines = order.OrderSummaries.Count(),
                       Total = order.OrderSummaries.Sum(item => item.Total)
                   };
        }

        public override Order Get(Order entity)
        {
            return DbSet
                .Include(p => p.FkOrdersCustomers)
                .Include(p => p.FkOrdersEmployees)
                .Include(p => p.FkOrdersShippers)
                .Include(p => p.OrderSummaries)
                .FirstOrDefault(item => item.OrderID == entity.OrderID);
        }
    }
}
