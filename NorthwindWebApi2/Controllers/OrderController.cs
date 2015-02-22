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
            if (Uow != null)
            {
                Uow.Dispose();
            }

            base.Dispose(disposing);
        }

        // GET: api/Order
        public HttpResponseMessage Get()
        {
            var result = new ApiResult();

            try
            {
                result.Model = Uow.OrderRepository.GetAll().OrderByDescending(item => item.OrderDate).ToList();
            }
            catch (Exception ex)
            {
                result.DidError = true;
                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/Order/5
        public HttpResponseMessage Get(Int32 id)
        {
            var result = new ApiResult();

            try
            {
                result.Model = Uow.OrderRepository.Get(new Order() { OrderID = id });
            }
            catch (Exception ex)
            {
                result.DidError = true;
                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
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
