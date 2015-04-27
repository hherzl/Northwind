using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Northwind.Core.BusinessLayer;
using Northwind.Core.EntityLayer;
using NorthwindWebApi2.Services;

namespace NorthwindWebApi2.Controllers
{
    public class ProductController : ApiController
    {
        protected ISalesUow Uow;

        public ProductController(IUowService service)
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

        // GET: api/Product
        public HttpResponseMessage Get()
        {
            var result = new ApiResult();

            try
            {
                result.Model = Uow.ProductRepository
                    .GetDetails()
                    .OrderByDescending(item => item.ProductID)
                    .ToList();
            }
            catch (Exception ex)
            {
                result.DidError = true;
                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/Product/5
        public HttpResponseMessage Get(Int32 id)
        {
            var result = new ApiResult();

            try
            {
                result.Model = Uow.ProductRepository.Get(new Product() { ProductID = id });
            }
            catch (Exception ex)
            {
                result.DidError = true;
                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/Product
        public HttpResponseMessage Post([FromBody]Product value)
        {
            var result = new ApiResult();

            try
            {
                Uow.ProductRepository.Add(value);

                Uow.CommitChanges();

                result.Model = value;
            }
            catch (Exception ex)
            {
                result.DidError = true;
                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // PUT: api/Product/5
        public HttpResponseMessage Put(Int32 id, [FromBody]Product value)
        {
            var result = new ApiResult();

            try
            {
                var entity = Uow.ProductRepository.Get(new Product() { ProductID = id });

                if (entity == null)
                {
                    result.DidError = true;
                    result.ErrorMessage = String.Format("There isn't a record with id: {0}", id); ;
                }
                else
                {
                    entity.ProductName = value.ProductName;
                    entity.QuantityPerUnit = value.QuantityPerUnit;

                    Uow.ProductRepository.Update(entity);

                    Uow.CommitChanges();

                    result.Model = value;

                    result.Message = "Update was successfully!";
                }
            }
            catch (Exception ex)
            {
                result.DidError = true;
                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // DELETE: api/Product/5
        public HttpResponseMessage Delete(Int32 id)
        {
            var result = new ApiResult();

            try
            {
                var entity = Uow.ProductRepository.Get(new Product() { ProductID = id });

                if (entity == null)
                {
                    result.DidError = true;
                    result.ErrorMessage = String.Format("There isn't a record with id: {0}", id); ;
                }
                else
                {
                    Uow.ProductRepository.Remove(entity);

                    Uow.CommitChanges();

                    result.Message = "Delete was successfully!";
                }
            }
            catch (Exception ex)
            {
                result.DidError = true;
                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
