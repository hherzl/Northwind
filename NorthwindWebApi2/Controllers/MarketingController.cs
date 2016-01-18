using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.DataLayer.Contracts;
using NorthwindWebApi2.Models;
using NorthwindWebApi2.Services;

namespace NorthwindWebApi2.Controllers
{
    public class MarketingController : ApiController
    {
        protected ISalesUow Uow;

        public MarketingController(IBusinessObjectService service)
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

        // GET: api/Marketin/TenMostExpensiveProducts
        [HttpGet]
        [Route("api/Marketing/TenMostExpensiveProducts")]
        public async Task<HttpResponseMessage> TenMostExpensiveProducts()
        {
            var result = new ApiResponse();

            try
            {
                result.Model = await Task.Run(() =>
                {
                    return Uow.ProductRepository.GetTenMostExpensiveProducts();
                });
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/Marketin/CustOrderHist/ABCDE
        [HttpGet]
        [Route("api/Marketing/CustOrderHist/{customerId}")]
        public async Task<HttpResponseMessage> CustOrderHist(String customerId)
        {
            var result = new ApiResponse();

            try
            {
                result.Model = await Task.Run(() =>
                {
                    return Uow.CustomerRepository.GetCustOrderHist(customerId);
                });
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
