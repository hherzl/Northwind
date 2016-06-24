using System;
using System.Linq;
using System.Net;
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
        // GET: api/Supplier
        [HttpGet]
        [Route("Supplier")]
        public async Task<HttpResponseMessage> GetSuppliers()
        {
            var response = new ComposedModelResponse<SupplierDetailViewModel>() as IComposedModelResponse<SupplierDetailViewModel>;

            try
            {
                response.Model = await Task.Run(() =>
                    {
                        return BusinessObject.GetSuppliers().Select(item => new SupplierDetailViewModel(item)).ToList();
                    });
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // GET: api/Supplier/5
        [HttpGet]
        [Route("Supplier")]
        public async Task<HttpResponseMessage> GetSupplier(Int32 id)
        {
            var response = new SingleModelResponse<Supplier>() as ISingleModelResponse<Supplier>;

            try
            {
                response.Model = await Task.Run(() =>
                    {
                        return BusinessObject.GetSupplier(new Supplier(id));
                    });
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // POST: api/Supplier
        [HttpPost]
        [Route("Supplier")]
        public async Task<HttpResponseMessage> CreateSupplier([FromBody]Supplier value)
        {
            var response = new SingleModelResponse<Supplier>() as ISingleModelResponse<Supplier>;

            try
            {
                response.Model = await Task.Run(() =>
                    {
                        return BusinessObject.CreateSupplier(value);
                    });
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // PUT: api/Supplier/5
        [HttpPut]
        [Route("Supplier")]
        public async Task<HttpResponseMessage> UpdateSupplier(Int32 id, [FromBody]Supplier value)
        {
            var response = new SingleModelResponse<Supplier>() as ISingleModelResponse<Supplier>;

            try
            {
                response.Model = await Task.Run(() =>
                    {
                        return BusinessObject.UpdateSupplier(value);
                    });
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // DELETE: api/Supplier/5
        [HttpDelete]
        [Route("Supplier")]
        public async Task<HttpResponseMessage> DeleteSupplier(Int32 id)
        {
            var response = new SingleModelResponse<Supplier>() as ISingleModelResponse<Supplier>;

            try
            {
                var entity = await Task.Run(() =>
                    {
                        return BusinessObject.DeleteSupplier(new Supplier(id));
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
