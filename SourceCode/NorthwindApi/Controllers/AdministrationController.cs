using System;
using System.Web.Http;
using Northwind.Core.BusinessLayer.Contracts;
using NorthwindApi.Services;

namespace NorthwindApi.Controllers
{
    [RoutePrefix("api/Administration")]
    public partial class AdministrationController : ApiController
    {
        protected ISalesBusinessObject BusinessObject;

        public AdministrationController(IBusinessObjectService service)
        {
            BusinessObject = service.GetSalesBusinessObject();
        }

        protected override void Dispose(Boolean disposing)
        {
            if (BusinessObject != null)
            {
                BusinessObject.Release();
            }

            base.Dispose(disposing);
        }

    }
}
