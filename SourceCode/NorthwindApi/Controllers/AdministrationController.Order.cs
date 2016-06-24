using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.EntityLayer;
using NorthwindApi.Helpers;
using NorthwindApi.Responses;
using NorthwindApi.ViewModels;

namespace NorthwindApi.Controllers
{
    public partial class AdministrationController : ApiController
    {
        // GET: api/Order
        [HttpGet]
        [Route("Order")]
        public async Task<HttpResponseMessage> GetOrders(Int32? orderID, String customerID, Int32? employeeID, Int32? shipperID)
        {
            var response = new ComposedModelResponse<OrderSummaryViewModel>() as IComposedModelResponse<OrderSummaryViewModel>;

            try
            {
                var query = await Task.Run(() =>
                {
                    return BusinessObject.GetOrderSummaries(customerID, employeeID, shipperID);
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
        [HttpGet]
        [Route("Order")]
        public async Task<HttpResponseMessage> GetOrder(Int32 id)
        {
            var response = new SingleModelResponse<Order>() as ISingleModelResponse<Order>;

            try
            {
                var entity = await Task.Run(() =>
                {
                    return BusinessObject.GetOrder(new Order(id));
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
        [HttpPost]
        [Route("Order")]
        public async Task<HttpResponseMessage> CreateOrder([FromBody]Order value)
        {
            var response = new SingleModelResponse<Order>() as ISingleModelResponse<Order>;

            try
            {
                var entity = await Task.Run(() =>
                {
                    return BusinessObject.CreateOrder(value);
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
