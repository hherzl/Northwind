using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindWebApi2.Controllers;
using NorthwindWebApi2.Models;
using NorthwindWebApi2.Services;

namespace NorthwindWebApi2.Tests.Controllers
{
    [TestClass]
    public class ShipperControllerTest
    {
        [TestMethod]
        public async Task Get()
        {
            // Arrange
            var controller = new ShipperController(new UowService());
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var httpResponse = await controller.Get();

            var shipperResponse = default(ApiResponse);

            httpResponse.TryGetContentValue<ApiResponse>(out shipperResponse);

            // Assert
            Assert.IsNotNull(shipperResponse);
        }

        [TestMethod]
        public async Task GetById()
        {
            // Arrange
            var controller = new ShipperController(new UowService());
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var httpResponse = await controller.Get(1);

            var shipperResponse = default(ApiResponse);

            httpResponse.TryGetContentValue<ApiResponse>(out shipperResponse);

            // Assert
            Assert.IsNotNull(shipperResponse);
        }
    }
}
