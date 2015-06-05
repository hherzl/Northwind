using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Northwind.Core.DataLayer.OperationContracts;
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
        public HttpResponseMessage Get()
        {
            var result = new ApiResult();

            try
            {
                var list = Uow.CategoryRepository
                    .GetAll()
                    .OrderByDescending(item => item.CategoryID)
                    .ToList();

                list.ForEach(i => i.Picture = null);

                result.Model = list;
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/Category/5
        public HttpResponseMessage Get(Int32 id)
        {
            var result = new ApiResult();

            try
            {
                result.Model = Uow.CategoryRepository.Get(new Category() { CategoryID = id });
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/Category
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Category/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Category/5
        public void Delete(int id)
        {
        }
    }
}
