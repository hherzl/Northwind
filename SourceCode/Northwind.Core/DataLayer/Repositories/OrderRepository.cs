using System;
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

        public IEnumerable<OrderSummary> GetSummaries(String customerID, Int32? employeeID, Int32? shipperID)
        {
            var query = from order in DbContext.Set<Order>()
                join customer in DbContext.Set<Customer>() on order.CustomerID equals customer.CustomerID
                join employee in DbContext.Set<Employee>() on order.EmployeeID equals employee.EmployeeID
                join shipper in DbContext.Set<Shipper>() on order.ShipVia equals shipper.ShipperID
                select new OrderSummary()
                {
                    OrderID = order.OrderID,
                    OrderDate = order.OrderDate,
                    CustomerID = order.CustomerID,
                    CustomerName = customer.CompanyName,
                    EmployeeID = order.EmployeeID,
                    EmployeeName = employee.FirstName + " " + employee.LastName,
                    ShipperID = order.ShipVia,
                    ShipperName = shipper.CompanyName,
                    Lines = order.OrderSummaries.Count(),
                    Total = order.OrderSummaries.Sum(item => item.Total)
                };

            if (!String.IsNullOrEmpty(customerID))
            {
                query = query.Where(item => item.CustomerID == customerID);
            }

            if (employeeID.HasValue)
            {
                query = query.Where(item => item.EmployeeID == employeeID);
            }

            if (shipperID.HasValue)
            {
                query = query.Where(item => item.ShipperID == shipperID);
            }

            return query;
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
