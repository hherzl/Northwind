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
        // GET: api/Shipper
        public async Task<HttpResponseMessage> GetShippers()
        {
            var response = new ComposedModelResponse<Shipper>() as IComposedModelResponse<Shipper>;

            try
            {
                response.Model = await Task.Run(() => { return BusinessObject.GetShippers().ToList(); });
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
        public async Task<HttpResponseMessage> GetShipper(Int32 id)
        {
            var response = new SingleModelResponse<Shipper>() as ISingleModelResponse<Shipper>;

            try
            {
                response.Model = await Task.Run(() => { return BusinessObject.GetShipper(new Shipper(id)); });
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
        public async Task<HttpResponseMessage> CreateShipper([FromBody]Shipper value)
        {
            var response = new SingleModelResponse<Shipper>() as ISingleModelResponse<Shipper>;

            try
            {
                var entity = await Task.Run(() => { return BusinessObject.CreateShipper(value); });

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
        public async Task<HttpResponseMessage> UpdateShipper(Int32 id, [FromBody]Shipper value)
        {
            var response = new SingleModelResponse<Shipper>() as ISingleModelResponse<Shipper>;

            try
            {
                response.Model = await Task.Run(() => { return BusinessObject.UpdateShipper(value); });
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
        public async Task<HttpResponseMessage> DeleteShipper(Int32 id)
        {
            var response = new SingleModelResponse<Shipper>() as ISingleModelResponse<Shipper>;

            try
            {
                response.Model = await Task.Run(() => { return BusinessObject.DeleteShipper(new Shipper(id)); });
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
