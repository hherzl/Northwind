using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindApi.Controllers;
using NorthwindApi.Responses;
using NorthwindApi.Services;
using NorthwindApi.ViewModels;

namespace NorthwindApi.Tests.Controllers
{
    [TestClass]
    public class OrderControllerTest
    {
        public OrderControllerTest()
        {

        }

        private IUowService service;

        [TestInitialize]
        public void Init()
        {
            service = new UowService();
        }

        [TestMethod]
        public async Task GetAsync()
        {
            // Arrange
            var controller = new OrderController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.Get();

            // Assert
            var value = default(IComposedViewModelResponse<OrderSummaryViewModel>);

            result.TryGetContentValue(out value);

            Assert.IsNotNull(value.Model);
        }
    }
}
