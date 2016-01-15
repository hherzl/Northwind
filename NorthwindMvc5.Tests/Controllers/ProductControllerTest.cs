using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindMvc5.Areas.Administration.Controllers;
using NorthwindMvc5.Services;

namespace NorthwindMvc5.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public async Task Index()
        {
            // Arrange
            ProductController controller = new ProductController(new UowService());

            // Act
            ViewResult result = await controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Create()
        {
            // Arrange
            ProductController controller = new ProductController(new UowService());

            // Act
            ViewResult result = await controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
