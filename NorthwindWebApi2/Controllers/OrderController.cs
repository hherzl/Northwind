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
    public class OrderController : ApiController
    {
        protected ISalesUow Uow;

        public OrderController(IUowService service)
        {
            Uow = service.GetSalesUow();
        }

        protected override void Dispose(Boolean disposing)
        {
            Uow.Dispose();

            base.Dispose(disposing);
        }

        // GET: api/Order
        public HttpResponseMessage Get()
        {
            var list = Uow.OrderRepository.GetAll().OrderByDescending(item => item.OrderDate).Take(10).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        // GET: api/Order/5
        public HttpResponseMessage Get(Int32 id)
        {
            var entity = Uow.OrderRepository.Get(new Order() { OrderID = id });

            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        // POST: api/Order
        public void Post([FromBody]Order value)
        {
        }

        // PUT: api/Order/5
        public void Put(Int32 id, [FromBody]Order value)
        {
        }

        // DELETE: api/Order/5
        public void Delete(Int32 id)
        {
        }
    }
}
