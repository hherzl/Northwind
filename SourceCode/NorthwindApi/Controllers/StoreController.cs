using System;
using System.Web.Http;
using Northwind.Core.BusinessLayer.Contracts;
using NorthwindApi.Services;

namespace NorthwindApi.Controllers
{
    [RoutePrefix("api/Store")]
    public class StoreController : ApiController
    {
        protected IStoreBusinessObject BusinessObject;

        public StoreController(IBusinessObjectService service)
        {
            BusinessObject = service.GetStoreBusinessObject();
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
