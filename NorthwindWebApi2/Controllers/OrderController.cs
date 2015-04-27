using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.BusinessLayer;
using Northwind.Core.EntityLayer;
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
        public async Task<HttpResponseMessage> Get()
        {
            var result = new ApiResult();

            try
            {
                result.Model = await Uow.OrderRepository
                    .GetSummaries()
                    .OrderByDescending(item => item.OrderDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/Order/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var result = new ApiResult();

            try
            {
                result.Model = await Uow.OrderRepository
                    .Get(id);
            }
            catch (Exception ex)
            {
                result.DidError = true;
                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/Order
        public HttpResponseMessage Post([FromBody]Order value)
        {
            var result = new ApiResult();

            try
            {
                Uow.CreateOrder(value, value.OrderDetails.ToArray());

                result.Model = value;
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
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
