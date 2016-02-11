using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Core.BusinessLayer;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.DataLayer;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.Mocks
{
    [TestClass]
    public class OrderMock
    {
        [TestMethod]
        public async Task IncreaseStocks()
        {
            var uow = new SalesUow(new SalesDbContext()) as ISalesUow;

            var businessObject = new SalesBusinessObject(uow) as ISalesBusinessObject;

            var productsTask = await businessObject.GetProductsDetails(String.Empty, null, null);

            var products = productsTask.ToList();

            foreach (var item in products)
            {
                var entity = await businessObject.GetProduct(new Product(item.ProductID));

                entity.UnitsInStock += 100;

                await businessObject.UpdateProduct(entity);
            }

            businessObject.Release();
        }

        [TestMethod]
        public async Task CreateOrder()
        {
            var uow = new SalesUow(new SalesDbContext()) as ISalesUow;

            var businessObject = new SalesBusinessObject(uow) as ISalesBusinessObject;

            var customersTask = await businessObject.GetCustomers();
            var employeesTask = await businessObject.GetEmployees();
            var shippersTask = await businessObject.GetShippers();

            var customers = customersTask.ToList();
            var employees = employeesTask.ToList();
            var shippers = shippersTask.ToList();

            var header = new Order();

            var selectecCustomer = customers[0];
            var selectedEmployee = employees[0];
            var selectedShipper = shippers[0];

            header.CustomerID = selectecCustomer.CustomerID;
            header.EmployeeID = selectedEmployee.EmployeeID;
            header.OrderDate = DateTime.Now;
            header.RequiredDate = DateTime.Now.AddDays(7);
            header.ShippedDate = null;
            header.ShipVia = selectedShipper.ShipperID;
            header.Freight = 25.0m;
            header.ShipName = selectecCustomer.CompanyName;
            header.ShipAddress = selectecCustomer.Address;
            header.ShipCity = selectecCustomer.City;
            header.ShipRegion = selectecCustomer.Region;
            header.ShipPostalCode = selectecCustomer.PostalCode;
            header.ShipCountry = selectecCustomer.Country;

            header.OrderSummaries = new Collection<OrderDetailSummary>()
            {
                new OrderDetailSummary { ProductID = 1, Quantity = 3, Discount = 0.0m },
                new OrderDetailSummary { ProductID = 10, Quantity = 2, Discount = 0.0m },
                new OrderDetailSummary { ProductID = 20, Quantity = 1, Discount = 0.0m }
            };

            var entity = await businessObject.CreateOrder(header);

            Console.WriteLine("Order #: {0}", entity.OrderID);

            businessObject.Release();
        }
    }
}
