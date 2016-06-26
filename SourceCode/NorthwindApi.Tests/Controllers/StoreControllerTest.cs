using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindApi.Services;

namespace NorthwindApi.Tests.Controllers
{
    [TestClass]
    public class StoreControllerTest
    {
        public StoreControllerTest()
        {

        }

        private IBusinessObjectService service;

        [TestInitialize]
        public void Init()
        {
            service = new BusinessObjectService();
        }
    }
}
