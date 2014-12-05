using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Core.BusinessLayer;
using Northwind.Core.DataLayer;
using Northwind.Core.PocoLayer;

namespace Northwind.Core.Tests
{
    [TestClass]
    public class OrderUnitTest
    {
        [TestMethod]
        public void CreateOrder()
        {
            var header = new Order();

            header.OrderID = 0;
            header.CustomerID = "ANATR";
            header.EmployeeID = 6;
            header.OrderDate = DateTime.Now;
            header.RequiredDate = DateTime.Now.AddDays(7);
            header.ShippedDate = null;
            header.ShipVia = 1;
            header.Freight = 25.0m;
            header.ShipName = "Steve Jobs";
            header.ShipAddress = "Redmon II";
            header.ShipCity = "Washington";
            header.ShipRegion = "West";
            header.ShipPostalCode = "12345";
            header.ShipCountry = "USA";

            var details = new List<OrderDetail>();

            details.Add(
                new OrderDetail()
                {
                    OrderID = header.OrderID,
                    ProductID = 1,
                    UnitPrice = 9.99m,
                    Quantity = 3,
                    Discount = 0.0f
                });

            details.Add(
                new OrderDetail()
                {
                    OrderID = header.OrderID,
                    ProductID = 10,
                    UnitPrice = 19.99m,
                    Quantity = 2,
                    Discount = 0.0f
                });

            details.Add(
                new OrderDetail()
                {
                    OrderID = header.OrderID,
                    ProductID = 20,
                    UnitPrice = 29.99m,
                    Quantity = 1,
                    Discount = 0.0f
                });

            details.Add(
                new OrderDetail()
                {
                    OrderID = header.OrderID,
                    ProductID = 25,
                    UnitPrice = 39.99m,
                    Quantity = 1,
                    Discount = 0.0f
                });

            var dbContext = new SalesDbContext();

            ISalesUow uow = new SalesUow(dbContext);

            uow.CreateOrder(header, details.ToArray());

            Console.WriteLine("Order #: {0}", header.OrderID);

            uow.Dispose();
        }
    }
}
