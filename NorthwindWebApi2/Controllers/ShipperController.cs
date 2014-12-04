using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Northwind.Core.BusinessLayer;
using Northwind.Core.DataLayer;
using Northwind.Core.PocoLayer;
using NorthwindWebApi2.Services;

namespace NorthwindWebApi2.Controllers
{
    public class ShipperController : ApiController
    {
        ISalesUow uow;

        public ShipperController(IUowService service)
        {
            uow = service.GetSalesUow();
        }

        protected override void Dispose(bool disposing)
        {
            uow.Dispose();

            base.Dispose(disposing);
        }

        // GET: api/Shipper
        public HttpResponseMessage Get()
        {
            var list = uow.ShipperRepository.GetAll().ToList();

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        // GET: api/Shipper/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Shipper
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Shipper/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            var entity = uow.ShipperRepository.Get(new Shipper() { ShipperID = id });

            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Error");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Update was successfully!");
        }

        // DELETE: api/Shipper/5
        public void Delete(int id)
        {
        }
    }
}
