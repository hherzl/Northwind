using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Core.EntityLayer;
using NorthwindApi.Controllers;
using NorthwindApi.Responses;

namespace NorthwindApi.Tests.Controllers
{
    public partial class AdministrationControllerTest
    {
        [TestMethod]
        public async Task Administration_GetShippersAsync()
        {
            // Arrange
            var controller = new AdministrationController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.GetShippers();

            // Assert
            var value = default(IComposedModelResponse<Shipper>);

            result.TryGetContentValue(out value);

            Assert.IsNotNull(value.Model);
            Assert.IsNotNull(value.Model.Count() > 0);
        }

        [TestMethod]
        public async Task Administration_GetShipperAsync()
        {
            // Arrange
            var controller = new AdministrationController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.GetShipper(1);

            // Assert
            var response = default(ISingleModelResponse<Shipper>);

            result.TryGetContentValue(out response);

            Assert.IsNotNull(response.Model);
        }

        [TestMethod]
        public async Task Administration_CreateShipperAsync()
        {
            // Arrange
            var controller = new AdministrationController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var model = new Shipper()
            {
                CompanyName = "Acme",
                Phone = "12345 67890"
            };

            var result = await controller.CreateShipper(model);

            // Assert
            var response = default(ISingleModelResponse<Shipper>);

            result.TryGetContentValue(out response);

            Assert.IsNotNull(response.Model.ShipperID);
        }

        [TestMethod]
        public async Task Administration_UpdateShipperAsync()
        {
            // Arrange
            var controller = new AdministrationController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var model = new Shipper()
            {
                CompanyName = "Acme 2",
                Phone = "22445 77990"
            };

            var result = await controller.UpdateShipper(8, model);

            // Assert
            var value = default(ISingleModelResponse<Shipper>);

            result.TryGetContentValue(out value);

            Assert.IsTrue(value.Message == "Record updated successfully");
        }

        [TestMethod]
        public async Task Administration_DeleteShipperAsync()
        {
            // Arrange
            var controller = new AdministrationController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.DeleteShipper(8);

            // Assert
            var value = default(ISingleModelResponse<Shipper>);

            result.TryGetContentValue(out value);

            Assert.IsTrue(value.Message == "Record deleted successfully");
        }
    }
}
