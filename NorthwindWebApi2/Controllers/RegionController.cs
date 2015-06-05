using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Northwind.Core.DataLayer;
using Northwind.Core.DataLayer.OperationContracts;
using NorthwindWebApi2.Models;
using NorthwindWebApi2.Services;

namespace NorthwindWebApi2.Controllers
{
    public class RegionController : ApiController
    {
        protected ISalesUow Uow;

        public RegionController(IUowService service)
        {
            Uow = service.GetSalesUow();
        }

        protected override void Dispose(Boolean disposing)
        {
            if (Uow != null)
            {
                Uow.Dispose();
            }

            base.Dispose(disposing);
        }

        // GET: api/Region
        public HttpResponseMessage Get()
        {
            var result = new ApiResult();

            try
            {
                result.Model = Uow.RegionRepository
                    .GetAll()
                    .ToList();
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/Region/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Region
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Region/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Region/5
        public void Delete(int id)
        {
        }
    }
}
