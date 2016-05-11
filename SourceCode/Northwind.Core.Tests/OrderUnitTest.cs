using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Core.BusinessLayer;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.DataLayer;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.Tests
{
    [TestClass]
    public class OrderUnitTest
    {
        [TestMethod]
        public async Task CreateOrder()
        {
            var header = new Order();

            header.CustomerID = "ANATR";
            header.EmployeeID = 6;
            header.OrderDate = DateTime.Now;
            header.RequiredDate = DateTime.Now.AddDays(7);
            header.ShippedDate = null;
            header.ShipVia = 1;
            header.Freight = 25.0m;
            header.ShipName = "Bill Gates";
            header.ShipAddress = "Redmon II";
            header.ShipCity = "Washington";
            header.ShipRegion = "West";
            header.ShipPostalCode = "12345";
            header.ShipCountry = "USA";

            header.OrderSummaries = new Collection<OrderDetailSummary>()
            {
                new OrderDetailSummary { ProductID = 1, Quantity = 3, Discount = 0.0m },
                new OrderDetailSummary { ProductID = 10, Quantity = 2, Discount = 0.0m },
                new OrderDetailSummary { ProductID = 20, Quantity = 1, Discount = 0.0m },
                new OrderDetailSummary { ProductID = 30, Quantity = 1, Discount = 0.0m }
            };

            var dbContext = new SalesDbContext();

            dbContext.Database.Log = s => Console.WriteLine(s);

            var uow = new SalesUow(dbContext) as ISalesUow;

            var businessObject = new SalesBusinessObject(uow) as ISalesBusinessObject;

            var entity = await Task.Run(() =>
            {
                return businessObject.CreateOrder(header);
            });

            Console.WriteLine("Order #: {0}", entity.OrderID);

            businessObject.Release();
        }
    }
}
