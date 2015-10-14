using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Core.EntityLayer;
using NorthwindApi.Controllers;
using NorthwindApi.Services;

namespace NorthwindApi.Tests.Controllers
{
    [TestClass]
    public class ShipperControllerTest
    {
        IUowService service;

        [TestInitialize]
        public void Init()
        {
            service = new UowService();
        }

        [TestMethod]
        public async Task GetAsync()
        {
            // Arrange
            var controller = new ShipperController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.Get();

            // Assert
            var value = default(IEnumerable<Shipper>);

            result.TryGetContentValue(out value);

            Assert.IsNotNull(value);
        }

        [TestMethod]
        public async Task GetByIdAsync()
        {
            // Arrange
            var controller = new ShipperController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.Get(1);

            // Assert
            var value = default(Shipper);

            result.TryGetContentValue(out value);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task PostAsync()
        {
            // Arrange
            var controller = new ShipperController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var model = new Shipper()
            {
                CompanyName = "Acme",
                Phone = "12345 67890"
            };

            var result = await controller.Post(model);

            // Assert
            var value = default(Int32?);

            result.TryGetContentValue(out value);

            Assert.IsTrue(value.HasValue);
        }

        [TestMethod]
        public async Task PutAsync()
        {
            // Arrange
            var controller = new ShipperController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var model = new Shipper()
            {
                CompanyName = "Acme 2",
                Phone = "22445 77990"
            };

            var result = await controller.Put(4, model);

            // Assert
            Assert.IsTrue(result.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task DeleteAsync()
        {
            // Arrange
            var controller = new ShipperController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.Delete(5);

            // Assert
            Assert.IsTrue(result.StatusCode == HttpStatusCode.OK);
        }
    }
}
