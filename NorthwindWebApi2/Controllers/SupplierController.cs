using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Northwind.Core.BusinessLayer;
using NorthwindWebApi2.Services;

namespace NorthwindWebApi2.Controllers
{
    public class SupplierController : ApiController
    {
        protected ISalesUow Uow;

        public SupplierController(IUowService service)
        {
            Uow = service.GetSalesUow();
        }

        protected override void Dispose(Boolean disposing)
        {
            Uow.Dispose();

            base.Dispose(disposing);
        }

        // GET: api/Supplier
        public HttpResponseMessage Get()
        {
            var list = Uow.SupplierRepository.GetAll().ToList();

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        // GET: api/Supplier/5
        public string Get(Int32 id)
        {
            return "value";
        }

        // POST: api/Supplier
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Supplier/5
        public void Put(Int32 id, [FromBody]string value)
        {
        }

        // DELETE: api/Supplier/5
        public void Delete(Int32 id)
        {
        }
    }
}
