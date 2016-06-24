using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindApi.Services;

namespace NorthwindApi.Tests.Controllers
{
    [TestClass]
    public partial class AdministrationControllerTest
    {
        public AdministrationControllerTest()
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
