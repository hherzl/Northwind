using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.EntityLayer;
using NorthwindApi.Helpers;
using NorthwindApi.Responses;

namespace NorthwindApi.Controllers
{
    public partial class AdministrationController : ApiController
    {
        // GET: api/Region
        [HttpGet]
        [Route("Region")]
        public async Task<HttpResponseMessage> GetRegions()
        {
            var response = new ComposedModelResponse<Region>() as IComposedModelResponse<Region>;

            try
            {
                response.Model = await Task.Run(() =>
                    {
                        return BusinessObject.GetRegions().ToList();
                    });
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
        [HttpGet]
        [Route("Region")]
        public async Task<HttpResponseMessage> GetRegion(Int32 id)
        {
            var response = new SingleModelResponse<Region>() as ISingleModelResponse<Region>;

            try
            {
                response.Model = await Task.Run(() =>
                    {
                        return BusinessObject.GetRegion(new Region(id));
                    });
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
        [HttpPost]
        [Route("Region")]
        public async Task<HttpResponseMessage> CreateRegion([FromBody]Region value)
        {
            var response = new SingleModelResponse<Region>() as ISingleModelResponse<Region>;

            try
            {
                var entity = await Task.Run(() =>
                    {
                        return BusinessObject.CreateRegion(value);
                    });

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
        [HttpPut]
        [Route("Region")]
        public async Task<HttpResponseMessage> UpdateRegion(Int32 id, [FromBody]Region value)
        {
            var response = new SingleModelResponse<Region>() as ISingleModelResponse<Region>;

            try
            {
                var entity = await Task.Run(() =>
                    {
                        return BusinessObject.UpdateRegion(value);
                    });

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
        [HttpDelete]
        [Route("Region")]
        public async Task<HttpResponseMessage> DeleteRegion(Int32 id)
        {
            var response = new SingleModelResponse<Region>() as ISingleModelResponse<Region>;

            try
            {
                var entity = await Task.Run(() =>
                    {
                        return BusinessObject.DeleteRegion(new Region(id));
                    });

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
