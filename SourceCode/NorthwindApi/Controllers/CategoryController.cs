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
using NorthwindApi.ViewModels;

namespace NorthwindApi.Controllers
{
    public class CategoryController : ApiController
    {
        protected ISalesBusinessObject BusinessObject;

        public CategoryController(IBusinessObjectService service)
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

        // GET: api/Category
        public async Task<HttpResponseMessage> Get()
        {
            var response = new ComposedModelResponse<CategoryViewModel>() as IComposedModelResponse<CategoryViewModel>;

            try
            {
                var task = await BusinessObject.GetCategories();

                response.Model = task.Select(item => new CategoryViewModel(item)).ToList();
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // GET: api/Category/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new SingleModelResponse<CategoryViewModel>() as ISingleModelResponse<CategoryViewModel>;

            try
            {
                var entity = await BusinessObject.GetCategory(new Category(id));

                response.Model = new CategoryViewModel(entity);
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // POST: api/Category
        public async Task<HttpResponseMessage> Post([FromBody]Category value)
        {
            var response = new SingleModelResponse<CategoryViewModel>() as ISingleModelResponse<CategoryViewModel>;

            try
            {
                var entity = await BusinessObject.CreateCategory(value);

                response.Model = new CategoryViewModel(entity);
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // PUT: api/Category/5
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]Category value)
        {
            var response = new SingleModelResponse<CategoryViewModel>() as ISingleModelResponse<CategoryViewModel>;

            try
            {
                var entity = await BusinessObject.UpdateCategory(value);

                response.Model = new CategoryViewModel(entity);
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // DELETE: api/Category/5
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            var response = new SingleModelResponse<CategoryViewModel>() as ISingleModelResponse<CategoryViewModel>;

            try
            {
                var entity = await BusinessObject.DeleteCategory(new Category(id));

                response.Model = new CategoryViewModel(entity);
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
