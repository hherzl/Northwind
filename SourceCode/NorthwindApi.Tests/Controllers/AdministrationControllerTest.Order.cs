using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindApi.Controllers;
using NorthwindApi.Responses;
using NorthwindApi.ViewModels;

namespace NorthwindApi.Tests.Controllers
{
    public partial class AdministrationControllerTest
    {
        [TestMethod]
        public async Task Administration_GetOrdersAsync()
        {
            // Arrange
            var controller = new AdministrationController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var orderID = default(Int32?);
            var customerID = String.Empty;
            var employeeID = default(Int32?);
            var shipperID = default(Int32?);

            // Act
            var result = await controller.GetOrders(orderID, customerID, employeeID, shipperID);

            // Assert
            var value = default(IComposedModelResponse<OrderSummaryViewModel>);

            result.TryGetContentValue(out value);

            Assert.IsNotNull(value.Model);
            Console.WriteLine("Model.Count: {0}", value.Model.Count());
        }
    }
}
