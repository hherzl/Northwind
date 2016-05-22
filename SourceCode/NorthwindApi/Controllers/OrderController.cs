using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.EntityLayer;
using NorthwindApi.Helpers;
using NorthwindApi.Responses;
using NorthwindApi.Services;
using NorthwindApi.ViewModels;

namespace NorthwindApi.Controllers
{
    public class OrderController : ApiController
    {
        protected ISalesBusinessObject Uow;

        public OrderController(IBusinessObjectService service)
        {
            Uow = service.GetSalesBusinessObject();
        }

        protected override void Dispose(Boolean disposing)
        {
            if (Uow != null)
            {
                Uow.Release();
            }

            base.Dispose(disposing);
        }

        // GET: api/Order
        public async Task<HttpResponseMessage> Get(Int32? orderID, String customerID, Int32? employeeID, Int32? shipperID)
        {
            var response = new ComposedModelResponse<OrderSummaryViewModel>() as IComposedModelResponse<OrderSummaryViewModel>;

            try
            {
                var query = await Task.Run(() =>
                {
                    return Uow.GetOrderSummaries(customerID, employeeID, shipperID);
                });

                if (String.IsNullOrEmpty(customerID) && !employeeID.HasValue && !shipperID.HasValue)
                {
                    response.Model = query.Select(item => new OrderSummaryViewModel(item)).Take(100).ToList();
                }
                else
                {
                    response.Model = query.Select(item => new OrderSummaryViewModel(item)).ToList();
                }

                response.Message = String.Format("Total of records: {0}.", response.Model.Count());
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // GET: api/Order/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new SingleModelResponse<Order>() as ISingleModelResponse<Order>;

            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.GetOrder(new Order(id));
                });

                response.Model = entity;
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // POST: api/Order
        public async Task<HttpResponseMessage> Post([FromBody]Order value)
        {
            var response = new SingleModelResponse<Order>() as ISingleModelResponse<Order>;

            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.CreateOrder(value);
                });

                response.Model = entity;
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }
    }
}
