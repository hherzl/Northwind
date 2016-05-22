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
using NorthwindApi.ViewModels;

namespace NorthwindApi.Controllers
{
    public class SupplierController : ApiController
    {
        protected ISalesBusinessObject BusinessObject;

        public SupplierController(IBusinessObjectService service)
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

        // GET: api/Supplier
        public async Task<HttpResponseMessage> Get()
        {
            var response = new ComposedModelResponse<SupplierDetailViewModel>() as IComposedModelResponse<SupplierDetailViewModel>;

            try
            {
                var task = await BusinessObject.GetSuppliers();

                response.Model = task.Select(item => new SupplierDetailViewModel(item)).ToList();
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
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new SingleModelResponse<Supplier>() as ISingleModelResponse<Supplier>;

            try
            {
                response.Model = await BusinessObject.GetSupplier(new Supplier(id));
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
        public async Task<HttpResponseMessage> Post([FromBody]Supplier value)
        {
            var response = new SingleModelResponse<Supplier>() as ISingleModelResponse<Supplier>;

            try
            {
                await BusinessObject.CreateSupplier(value);

                response.Model = value;
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
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]Supplier value)
        {
            var response = new SingleModelResponse<Supplier>() as ISingleModelResponse<Supplier>;

            try
            {
                var entity = await BusinessObject.UpdateSupplier(value);

                response.Model = entity;
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
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            var response = new SingleModelResponse<Supplier>() as ISingleModelResponse<Supplier>;

            try
            {
                var entity = await BusinessObject.DeleteSupplier(new Supplier(id));

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
