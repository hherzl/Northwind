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

                entity.UnitsInStock += 9999;

                await businessObject.UpdateProduct(entity);
            }

            businessObject.Release();
        }

        async Task CreateData(DateTime startDate, DateTime endDate, Int32 limit, Decimal?[] freights)
        {
            var date = new DateTime(startDate.Year, startDate.Month, startDate.Day);

            var random = new Random();

            while (date <= endDate)
            {
                if (date.DayOfWeek != DayOfWeek.Sunday)
                {
                    var uow = new SalesUow(new SalesDbContext()) as ISalesUow;

                    var businessObject = new SalesBusinessObject(uow) as ISalesBusinessObject;

                    var customersTask = await businessObject.GetCustomers();
                    var employeesTask = await businessObject.GetEmployees();
                    var shippersTask = await businessObject.GetShippers();
                    var productsTask = await businessObject.GetProductsDetails(null, null, null);

                    var customers = customersTask.ToList();
                    var employees = employeesTask.ToList();
                    var shippers = shippersTask.ToList();
                    var products = productsTask.Where(item => item.Discontinued == false).ToList();

                    for (var j = 0; j < limit; j++)
                    {
                        var header = new Order();

                        var selectecCustomer = customers[random.Next(0, customers.Count - 1)];
                        var selectedEmployee = employees[random.Next(0, employees.Count - 1)];
                        var selectedShipper = shippers[random.Next(0, shippers.Count - 1)];

                        header.CustomerID = selectecCustomer.CustomerID;
                        header.EmployeeID = selectedEmployee.EmployeeID;
                        header.OrderDate = date;
                        header.RequiredDate = date.AddDays(7);
                        header.ShippedDate = null;
                        header.ShipVia = selectedShipper.ShipperID;
                        header.Freight = freights[random.Next(0, freights.Length)];
                        header.ShipName = selectecCustomer.CompanyName;
                        header.ShipAddress = selectecCustomer.Address;
                        header.ShipCity = selectecCustomer.City;
                        header.ShipRegion = selectecCustomer.Region;
                        header.ShipPostalCode = selectecCustomer.PostalCode;
                        header.ShipCountry = selectecCustomer.Country;

                        header.OrderSummaries = new Collection<OrderDetailSummary>() { };

                        var summaries = random.Next(1, 10);

                        for (var i = 0; i < summaries; i++)
                        {
                            var summary = new OrderDetailSummary
                            {
                                ProductID = products[random.Next(0, products.Count - 1)].ProductID,
                                Quantity = (Int16)random.Next(1, 10),
                                Discount = 0.0m
                            };

                            if (header.OrderSummaries.Where(item => item.ProductID == summary.ProductID).Count() == 0)
                            {
                                header.OrderSummaries.Add(summary);
                            }
                        }

                        var entity = await businessObject.CreateOrder(header);

                        Console.WriteLine("Order #: {0}", entity.OrderID);
                    }

                    businessObject.Release();
                }

                date = date.AddDays(1);
            }
        }

        [TestMethod]
        public async Task CreateOrder()
        {
            await CreateData(
                startDate: new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                endDate: new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)),
                limit: 10,
                freights: new Decimal?[] { 15.99m, 19.99m, 24.99m, 29.99m  }
            );
        }
    }
}
