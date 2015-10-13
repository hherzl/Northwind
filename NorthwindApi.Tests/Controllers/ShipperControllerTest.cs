using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Core.EntityLayer;
using NorthwindApi.Controllers;
using NorthwindApi.Services;

namespace NorthwindApi.Tests.Controllers
{
    [TestClass]
    public class ShipperControllerTest
    {
        IUowService service;

        [TestInitialize]
        public void Init()
        {
            service = new UowService();
        }

        [TestMethod]
        public async Task GetAsync()
        {
            // Arrange
            ShipperController controller = new ShipperController(service);

            // Act
            IEnumerable<Shipper> result = await controller.Get();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetByIdAsync()
        {
            // Arrange
            ShipperController controller = new ShipperController(service);

            // Act
            Shipper result = await controller.Get(1);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
