using System;
using System.Linq;
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
        // GET: api/Category
        [HttpGet]
        [Route("Category")]
        public async Task<HttpResponseMessage> GetCategories()
        {
            var response = new ComposedModelResponse<CategoryViewModel>() as IComposedModelResponse<CategoryViewModel>;

            try
            {
                response.Model = await Task.Run(() =>
                    {
                        return BusinessObject.GetCategories().Select(item => new CategoryViewModel(item)).ToList();
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

        // GET: api/Category/5
        [HttpGet]
        [Route("Category")]
        public async Task<HttpResponseMessage> GetCategory(Int32 id)
        {
            var response = new SingleModelResponse<CategoryViewModel>() as ISingleModelResponse<CategoryViewModel>;

            try
            {
                var entity = await Task.Run(() =>
                    {
                        return BusinessObject.GetCategory(new Category(id));
                    });

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
        [HttpPost]
        [Route("Category")]
        public async Task<HttpResponseMessage> CreateCategory([FromBody]Category value)
        {
            var response = new SingleModelResponse<CategoryViewModel>() as ISingleModelResponse<CategoryViewModel>;

            try
            {
                var entity = await Task.Run(() =>
                    {
                        return BusinessObject.CreateCategory(value);
                    });

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
        [HttpPut]
        [Route("Category")]
        public async Task<HttpResponseMessage> UpdateCategory(Int32 id, [FromBody]Category value)
        {
            var response = new SingleModelResponse<CategoryViewModel>() as ISingleModelResponse<CategoryViewModel>;

            try
            {
                var entity = await Task.Run(() =>
                    {
                        return BusinessObject.UpdateCategory(value);
                    });

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
        [HttpDelete]
        [Route("Category")]
        public async Task<HttpResponseMessage> DeleteCategory(Int32 id)
        {
            var response = new SingleModelResponse<CategoryViewModel>() as ISingleModelResponse<CategoryViewModel>;

            try
            {
                var entity = await Task.Run(() =>
                    {
                        return BusinessObject.DeleteCategory(new Category(id));
                    });

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
