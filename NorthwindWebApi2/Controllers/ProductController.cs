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
            Uow.ProductRepository.Add(value);
            Uow.CommitChanges();
        }

        // PUT: api/Product/5
        public HttpResponseMessage Put(Int32 id, [FromBody]Product value)
        {
            var entity = Uow.ProductRepository.Get(new Product(){ProductID = id});
            if (entity ==null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Error");
            }

            entity.ProductName = value.ProductName;
            entity.QuantityPerUnit = value.QuantityPerUnit;

            Uow.ProductRepository.Update(entity);
            Uow.CommitChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Update was successfully!");
        }

        // DELETE: api/Product/5
        public HttpResponseMessage Delete(Int32 id)
        {
            var entity = Uow.ProductRepository.Get(new Product() { ProductID = id });
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Error");
            }

            Uow.ProductRepository.Remove(entity);
            Uow.CommitChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Delete was successfully!");
        }
    }
}
