using System.Data.Entity;
using System.Linq;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<OrderSummary> GetSummaries()
        {
            return from order in DbContext.Set<Order>()
                   join customer in DbContext.Set<Customer>() on order.CustomerID equals customer.CustomerID
                   join employee in DbContext.Set<Employee>() on order.EmployeeID equals employee.EmployeeID
                   join shipper in DbContext.Set<Shipper>() on order.ShipVia equals shipper.ShipperID
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
                .Include(p => p.OrderSummaries)
                .FirstOrDefault(item => item.OrderID == entity.OrderID);
        }
    }
}
