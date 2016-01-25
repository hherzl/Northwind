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
            var response = new ComposedCategoryResponse();

            try
            {
                var task = await BusinessObject.GetCategories();

                response.Model = task.Select(item => new CategoryViewModel(item)).ToList();
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.ErrorMessage = ex.Message;
                response.DidError = true;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // GET: api/Category/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new SingleCategoryResponse();

            try
            {
                response.Model = await BusinessObject.GetCategory(new Category(id));

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

        // POST: api/Category
        public async Task<HttpResponseMessage> Post([FromBody]Category value)
        {
            var response = new SingleCategoryResponse();

            try
            {
                await BusinessObject.CreateCategory(value);

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

        // PUT: api/Category/5
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]Category value)
        {
            var response = new SingleCategoryResponse();

            try
            {
                var entity = await BusinessObject.UpdateCategory(value);

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

        // DELETE: api/Category/5
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            var response = new SingleCategoryResponse();

            try
            {
                var entity = await BusinessObject.DeleteCategory(new Category(id));

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
