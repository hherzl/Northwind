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
        private IBusinessObjectService service;

        [TestInitialize]
        public void Init()
        {
            service = new BusinessObjectService();
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
            var value = default(IComposedViewModelResponse<Shipper>);

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
            var response = default(ISingleViewModelResponse<Shipper>);

            result.TryGetContentValue(out response);

            Assert.IsNotNull(response.Model.ShipperID);
        }

        [TestMethod]
        public async Task GetByIdAsync()
        {
            // Arrange
            var controller = new ShipperController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.Get(7);

            // Assert
            var response = default(ISingleViewModelResponse<Shipper>);

            result.TryGetContentValue(out response);

            Assert.IsNotNull(response.Model);
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

            var result = await controller.Put(8, model);

            // Assert
            var value = default(ISingleViewModelResponse<Shipper>);

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
            var result = await controller.Delete(8);

            // Assert
            var value = default(ISingleViewModelResponse<Shipper>);

            result.TryGetContentValue(out value);

            Assert.IsTrue(value.Message == "Record deleted successfully");
        }
    }
}
