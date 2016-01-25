using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;
using NorthwindApi.Helpers;
using NorthwindApi.Responses;
using NorthwindApi.Services;
using NorthwindApi.ViewModels;

namespace NorthwindApi.Controllers
{
    public class CategoryController : ApiController
    {
        protected ISalesUow Uow;

        public CategoryController(IUowService service)
        {
            Uow = service.GetSalesUow();
        }

        protected override void Dispose(Boolean disposing)
        {
            if (Uow != null)
            {
                Uow.Dispose();
            }

            base.Dispose(disposing);
        }

        // GET: api/Category
        public async Task<HttpResponseMessage> Get()
        {
            var response = new ComposedCategoryResponse();

            try
            {
                response.Model = await Task.Run(() =>
                {
                    return Uow
                        .CategoryRepository
                        .GetAll()
                        .Select(item => new CategoryViewModel(item))
                        .ToList();
                });
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
                response.Model = await Task.Run(() =>
                {
                    return new CategoryViewModel(Uow.CategoryRepository.Get(new Category(id)));
                });

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
        public async Task<HttpResponseMessage> Post([FromBody]CategoryViewModel value)
        {
            var response = new SingleCategoryResponse();

            try
            {
                var entity = value.ToEntity();

                Uow.CategoryRepository.Add(entity);

                if (await Uow.CommitChangesAsync() > 0)
                {
                    response.Message = "Record added successfully";
                    response.Model = new CategoryViewModel(entity);
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

        // PUT: api/Category/5
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]CategoryViewModel value)
        {
            var response = new SingleCategoryResponse();

            try
            {
                var entity = Uow.CategoryRepository.Get(new Category(id));

                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                entity.CategoryName = value.CategoryName;
                entity.Description = value.Description;

                Uow.CategoryRepository.Update(entity);

                if (await Uow.CommitChangesAsync() > 0)
                {
                    response.Message = "Record updated successfully";
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
                var entity = Uow.CategoryRepository.Get(new Category(id));

                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                Uow.CategoryRepository.Remove(entity);

                if (await Uow.CommitChangesAsync() > 0)
                {
                    response.Message = "Record deleted successfully";
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
