using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;
using NorthwindWebApi2.Models;
using NorthwindWebApi2.Services;

namespace NorthwindWebApi2.Controllers
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
            var result = new ApiResponse();

            try
            {
                result.Model = await Task.Run(() =>
                    {
                        return Uow
                            .CategoryRepository
                            .GetAll()
                            .OrderByDescending(item => item.CategoryID)
                            .ToList();
                    });
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/Category/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var result = new ApiResponse();

            try
            {
                result.Model = await Task.Run(() =>
                {
                    return Uow.CategoryRepository.Get(new Category(id));
                });
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/Category
        public void Post([FromBody]Category value)
        {

        }

        // PUT: api/Category/5
        public void Put(Int32 id, [FromBody]Category value)
        {

        }

        // DELETE: api/Category/5
        public void Delete(Int32 id)
        {

        }
    }
}
