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
            var response = new ComposedModelResponse<Region>() as IComposedModelResponse<Region>;

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

            return response.ToHttpResponse(Request);
        }

        // GET: api/Region/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new SingleModelResponse<Region>() as ISingleModelResponse<Region>;

            try
            {
                response.Model = await BusinessObject.GetRegion(new Region(id));
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.ErrorMessage = ex.Message;
                response.DidError = true;
            }

            return response.ToHttpResponse(Request);
        }

        // POST: api/Region
        public async Task<HttpResponseMessage> Post([FromBody]Region value)
        {
            var response = new SingleModelResponse<Region>() as ISingleModelResponse<Region>;

            try
            {
                var entity = await BusinessObject.CreateRegion(value);

                response.Model = entity;
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.ErrorMessage = ex.Message;
                response.DidError = true;
            }

            return response.ToHttpResponse(Request);
        }

        // PUT: api/Region/5
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]Region value)
        {
            var response = new SingleModelResponse<Region>() as ISingleModelResponse<Region>;

            try
            {
                var entity = await BusinessObject.UpdateRegion(value);

                response.Model = value;
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.ErrorMessage = ex.Message;
                response.DidError = true;
            }

            return response.ToHttpResponse(Request);
        }

        // DELETE: api/Region/5
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            var response = new SingleModelResponse<Region>() as ISingleModelResponse<Region>;

            try
            {
                var entity = await BusinessObject.DeleteRegion(new Region(id));

                response.Model = entity;
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.ErrorMessage = ex.Message;
                response.DidError = true;
            }

            return response.ToHttpResponse(Request);
        }
    }
}
