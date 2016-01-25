using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;
using NorthwindApi.Helpers;
using NorthwindApi.Responses;
using NorthwindApi.Services;

namespace NorthwindApi.Controllers
{
    public class RegionController : ApiController
    {
        protected ISalesBusinessObject BusinessObject;

        public RegionController(IBusinessObjectService service)
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

        // GET: api/Region
        public async Task<HttpResponseMessage> Get()
        {
            var response = new ComposedRegionResponse() as IComposedViewModelResponse<Region>;

            try
            {
                var task = await BusinessObject.GetRegions();

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

        // GET: api/Region/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new SingleRegionResponse() as ISingleViewModelResponse<Region>;

            try
            {
                response.Model = await BusinessObject.GetRegion(new Region(id));

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

        // POST: api/Region
        public async Task<HttpResponseMessage> Post([FromBody]Region value)
        {
            var response = new SingleRegionResponse() as ISingleViewModelResponse<Region>;

            try
            {
                await BusinessObject.CreateRegion(value);

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

        // PUT: api/Region/5
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]Region value)
        {
            var response = new SingleRegionResponse() as ISingleViewModelResponse<Region>;

            try
            {
                var entity = await BusinessObject.UpdateRegion(value);

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

        // DELETE: api/Region/5
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            var response = new SingleRegionResponse() as ISingleViewModelResponse<Region>;

            try
            {
                var entity = await BusinessObject.DeleteRegion(new Region(id));

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
