using System;
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
            var controller = new OrderController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var orderID = default(Int32?);
            var customerID = String.Empty;
            var employeeID = default(Int32?);
            var shipperID = default(Int32?);

            // Act
            var result = await controller.Get(orderID, customerID, employeeID, shipperID);

            // Assert
            var value = default(IComposedViewModelResponse<OrderSummaryViewModel>);

            result.TryGetContentValue(out value);

            Assert.IsNotNull(value.Model);
        }
    }
}
