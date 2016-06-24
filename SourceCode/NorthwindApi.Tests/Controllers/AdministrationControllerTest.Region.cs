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
        public async Task GetAsync()
        {
            // Arrange
            var controller = new AdministrationController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.GetCustomers();

            // Assert
            var value = default(IComposedModelResponse<Region>);

            result.TryGetContentValue(out value);

            Assert.IsNotNull(value.Model);
        }

        [TestMethod]
        public async Task AdministrationControllerTest_CreateRegionsAsync()
        {
            // Arrange
            var controller = new AdministrationController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var model = new Region()
            {
                RegionID = 5,
                RegionDescription = "Acme Region"
            };

            var result = await controller.CreateRegion(model);

            // Assert
            var response = default(ISingleModelResponse<Region>);

            result.TryGetContentValue(out response);

            Assert.IsNotNull(response.Model.RegionID);
        }

        [TestMethod]
        public async Task AdministrationControllerTest_CreateRegionAsync()
        {
            // Arrange
            var controller = new AdministrationController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.GetRegion(5);

            // Assert
            var response = default(ISingleModelResponse<Region>);

            result.TryGetContentValue(out response);

            Assert.IsNotNull(response.Model);
        }

        [TestMethod]
        public async Task AdministrationControllerTest_UpdateRegionAsync()
        {
            // Arrange
            var controller = new AdministrationController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var model = new Region()
            {
                RegionDescription = "Acme Region 2",
            };

            var result = await controller.UpdateRegion(5, model);

            // Assert
            var value = default(ISingleModelResponse<Region>);

            result.TryGetContentValue(out value);

            Assert.IsTrue(value.Message == "Record updated successfully");
        }

        [TestMethod]
        public async Task AdministrationControllerTest_DeleteRegionAsync()
        {
            // Arrange
            var controller = new AdministrationController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.DeleteRegion(5);

            // Assert
            var value = default(ISingleModelResponse<Region>);

            result.TryGetContentValue(out value);

            Assert.IsTrue(value.Message == "Record deleted successfully");
        }
    }
}
