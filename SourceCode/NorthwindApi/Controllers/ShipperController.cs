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

namespace NorthwindApi.Controllers
{
    public class ShipperController : ApiController
    {
        protected ISalesBusinessObject BusinessObject;

        public ShipperController(IBusinessObjectService service)
        {
            BusinessObject = service.GetSalesBusinessObject();
        }

        protected override void Dispose(Boolean disposing)
        {
            if (BusinessObject != null)
            {
                BusinessObject.Release();
            }

            base.Dispose(disposing);
        }

        // GET: api/Shipper
        public async Task<HttpResponseMessage> Get()
        {
            var response = new ComposedModelResponse<Shipper>() as IComposedModelResponse<Shipper>;

            try
            {
                var task = await BusinessObject.GetShippers();

                response.Model = task.ToList();
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.ErrorMessage = ex.Message;
                response.DidError = true;
            }

            return response.ToHttpResponse(Request);
        }

        // GET: api/Shipper/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new SingleModelResponse<Shipper>() as ISingleModelResponse<Shipper>;

            try
            {
                response.Model = await BusinessObject.GetShipper(new Shipper(id));
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // POST: api/Shipper
        public async Task<HttpResponseMessage> Post([FromBody]Shipper value)
        {
            var response = new SingleModelResponse<Shipper>() as ISingleModelResponse<Shipper>;

            try
            {
                var entity = await BusinessObject.CreateShipper(value);

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

        // PUT: api/Shipper/5
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]Shipper value)
        {
            var response = new SingleModelResponse<Shipper>() as ISingleModelResponse<Shipper>;

            try
            {
                var entity = await BusinessObject.UpdateShipper(value);

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

        // DELETE: api/Shipper/5
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            var response = new SingleModelResponse<Shipper>() as ISingleModelResponse<Shipper>;

            try
            {
                var entity = await BusinessObject.DeleteShipper(new Shipper(id));

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
