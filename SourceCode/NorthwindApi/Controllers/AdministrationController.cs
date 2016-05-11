using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.BusinessLayer.Contracts;
using NorthwindApi.Helpers;
using NorthwindApi.Responses;
using NorthwindApi.Services;
using NorthwindApi.ViewModels;  

namespace NorthwindApi.Controllers
{
    [RoutePrefix("api/Administration")]
    public class AdministrationController : ApiController
    {
        protected ISalesBusinessObject Uow;

        public AdministrationController(IBusinessObjectService service)
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
        [Route("Order")]
        public async Task<HttpResponseMessage> Get(Int32? orderID, String customerID, Int32? employeeID, Int32? shipperID)
        {
            var response = new ComposedViewModelResponse<OrderSummaryViewModel>() as IComposedViewModelResponse<OrderSummaryViewModel>;

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
    }
}
