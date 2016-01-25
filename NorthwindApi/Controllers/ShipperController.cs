using System;
using System.Linq;
using System.Net;
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
            var response = new ComposedShipperResponse() as IComposedViewModelResponse<Shipper>;

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

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // GET: api/Shipper/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new SingleShipperResponse() as ISingleViewModelResponse<Shipper>;

            try
            {
                response.Model = await BusinessObject.GetShipper(new Shipper(id));

                if (response.Model == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.ErrorMessage = ex.Message;
                response.DidError = true;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // POST: api/Shipper
        public async Task<HttpResponseMessage> Post([FromBody]Shipper value)
        {
            var response = new SingleShipperResponse() as ISingleViewModelResponse<Shipper>;

            try
            {
                await BusinessObject.CreateShipper(value);

                response.Model = value;
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.ErrorMessage = ex.Message;
                response.DidError = true;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // PUT: api/Shipper/5
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]Shipper value)
        {
            var response = new SingleShipperResponse() as ISingleViewModelResponse<Shipper>;

            try
            {
                var entity = await BusinessObject.UpdateShipper(value);

                if (entity == null)
                {
                    response.DidError = true;
                    response.ErrorMessage = String.Format("There isn't a record with id: {0}", id);
                }
                else
                {
                    response.Model = value;
                    response.Message = "Update was successfully!";
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.ErrorMessage = ex.Message;
                response.DidError = true;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // DELETE: api/Shipper/5
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            var response = new SingleShipperResponse() as ISingleViewModelResponse<Shipper>;

            try
            {
                var entity = await BusinessObject.DeleteShipper(new Shipper(id));

                if (entity == null)
                {
                    response.DidError = true;
                    response.ErrorMessage = String.Format("There isn't a record with id: {0}", id);
                }
                else
                {
                    response.Model = entity;
                    response.Message = "Delete was successfully!";
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.ErrorMessage = ex.Message;
                response.DidError = true;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
