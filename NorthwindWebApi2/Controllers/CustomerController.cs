using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Northwind.Core.BusinessLayer;
using Northwind.Core.PocoLayer;
using NorthwindWebApi2.Services;

namespace NorthwindWebApi2.Controllers
{
    public class CustomerController : ApiController
    {
        protected ISalesUow Uow;

        public CustomerController(IUowService service)
        {
            Uow = service.GetSalesUow();
        }

        protected override void Dispose(Boolean disposing)
        {
            Uow.Dispose();

            base.Dispose(disposing);}

        // GET: api/Customer
        public HttpResponseMessage Get()
        {
            var list = Uow.CustomerRepository.GetAll().ToList();

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        // GET: api/Customer/5
        public string Get(String id)
        {
            return "value";
        }

        // POST: api/Customer
        public void Post([FromBody]Customer value)
        {
        }

        // PUT: api/Customer/5
        public void Put(String id, [FromBody]Customer value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(String id)
        {
        }
    }
}
