using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Core.EntityLayer;
using NorthwindApi.Controllers;
using NorthwindApi.Responses;
using NorthwindApi.ViewModels;

namespace NorthwindApi.Tests.Controllers
{
    public partial class AdministrationControllerTest
    {
        [TestMethod]
        public async Task AdministrationControllerTest_GetCategoriesAsync()
        {
            // Arrange
            var controller = new AdministrationController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.GetCategories();

            // Assert
            var value = default(IComposedModelResponse<CategoryViewModel>);

            result.TryGetContentValue(out value);

            Assert.IsNotNull(value.Model);
        }

        [TestMethod]
        public async Task AdministrationControllerTest_CreateCategoryAsync()
        {
            // Arrange
            var controller = new AdministrationController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var model = new Category()
            {
                CategoryName = "Acme Category",
                Description = "Acme category description"
            };

            var result = await controller.CreateCategory(model);

            // Assert
            var response = default(ISingleModelResponse<CategoryViewModel>);

            result.TryGetContentValue(out response);

            Assert.IsNotNull(response.Model.CategoryID);
        }

        [TestMethod]
        public async Task AdministrationControllerTest_GetCategoryAsync()
        {
            // Arrange
            var controller = new AdministrationController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.GetCategory(7);

            // Assert
            var response = default(ISingleModelResponse<CategoryViewModel>);

            result.TryGetContentValue(out response);

            Assert.IsNotNull(response.Model);
        }

        [TestMethod]
        public async Task AdministrationControllerTest_UpdateCategoryAsync()
        {
            // Arrange
            var controller = new AdministrationController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var model = new Category()
            {
                CategoryName = "Acme 2",
                Description = "22445 77990"
            };

            var result = await controller.UpdateCategory(8, model);

            // Assert
            var value = default(ISingleModelResponse<CategoryViewModel>);

            result.TryGetContentValue(out value);

            Assert.IsTrue(value.Message == "Record updated successfully");
        }

        [TestMethod]
        public async Task AdministrationControllerTest_DeleteCategoryAsync()
        {
            // Arrange
            var controller = new AdministrationController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.DeleteCategory(9);

            // Assert
            var value = default(ISingleModelResponse<CategoryViewModel>);

            result.TryGetContentValue(out value);

            Assert.IsTrue(value.Message == "Record deleted successfully");
        }
    }
}
