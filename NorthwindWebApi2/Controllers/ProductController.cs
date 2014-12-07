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
        protected ISalesUow Uow;

        public ProductController(IUowService service)
        {
            Uow = service.GetSalesUow();
        }

        protected override void Dispose(Boolean disposing)
        {
            Uow.Dispose();

            base.Dispose(disposing);
        }

        // GET: api/Product
        public HttpResponseMessage Get()
        {
            var list = Uow.ProductRepository.GetDetails().OrderByDescending(item => item.ProductID).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        // GET: api/Product/5
        public HttpResponseMessage Get(Int32 id)
        {
            var entity = Uow.ProductRepository.Get(new Product() { ProductID = id });

            return Request.CreateResponse(HttpStatusCode.OK, entity);
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
