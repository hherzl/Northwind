using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Core.EntityLayer;
using NorthwindApi.Controllers;
using NorthwindApi.Responses;
using NorthwindApi.Services;

namespace NorthwindApi.Tests.Controllers
{
    [TestClass]
    public class ShipperControllerTest
    {
        private IUowService service;
        private Int32 id;

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
            var value = default(IComposedShipperResponse);

            result.TryGetContentValue(out value);

            Assert.IsNotNull(value.Model);
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
            var response = default(ISingleShipperResponse);

            result.TryGetContentValue(out response);

            Assert.IsNotNull(response.Value);
            Assert.IsTrue(response.Message == "Record added successfully");

            id = response.Value.Value;
        }

        [TestMethod]
        public async Task GetByIdAsync()
        {
            // Arrange
            var controller = new ShipperController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.Get(id);

            // Assert
            var response = default(ISingleShipperResponse);

            result.TryGetContentValue(out response);

            Assert.IsNotNull(response.Single);
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

            var result = await controller.Put(id, model);

            // Assert
            var value = default(ISingleShipperResponse);

            result.TryGetContentValue(out value);

            Assert.IsTrue(value.Message == "Record updated successfully");
        }

        [TestMethod]
        public async Task DeleteAsync()
        {
            // Arrange
            var controller = new ShipperController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.Delete(11);

            // Assert
            var value = default(ISingleShipperResponse);

            result.TryGetContentValue(out value);

            Assert.IsTrue(value.Message == "Record deleted successfully");
        }
    }
}
