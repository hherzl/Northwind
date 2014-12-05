using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Northwind.Core.BusinessLayer;
using Northwind.Core.PocoLayer;
using NorthwindWebApi2.Services;

namespace NorthwindWebApi2.Controllers
{
    public class ProductController : ApiController
    {
        ISalesUow uow;

        public ProductController(IUowService service)
        {
            uow = service.GetSalesUow();
        }

        protected override void Dispose(bool disposing)
        {
            uow.Dispose();

            base.Dispose(disposing);
        }

        // GET: api/Product
        public HttpResponseMessage Get()
        {
            var list = uow.ProductRepository.GetDetails().ToList();

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        // GET: api/Product/5
        public string Get(Int32 id)
        {
            return "value";
        }

        // POST: api/Product
        public void Post([FromBody]Product value)
        {
        }

        // PUT: api/Product/5
        public void Put(Int32 id, [FromBody]Product value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(Int32 id)
        {
        }
    }
}
