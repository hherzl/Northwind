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
    public class ProductController : ApiController
    {
        protected ISalesUow Uow;

        public ProductController(IBusinessObjectService service)
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
        public async Task<HttpResponseMessage> Get(String productName, Int32? supplierID, Int32? categoryID)
        {
            var result = new ApiResponse();

            try
            {
                result.Model = await Task.Run(() =>
                {
                    return Uow
                        .ProductRepository
                        .GetDetails(productName, supplierID, categoryID)
                        .OrderByDescending(item => item.ProductID)
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

        // GET: api/Product/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var result = new ApiResponse();

            try
            {
                result.Model = await Task.Run(() =>
                {
                    return Uow
                        .ProductRepository
                        .Get(new Product(id));
                });
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }



        // POST: api/Product
        public async Task<HttpResponseMessage> Post([FromBody]Product value)
        {
            var result = new ApiResponse();

            try
            {
                Uow.ProductRepository.Add(value);

                await Uow.CommitChangesAsync();

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
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]Product value)
        {
            var result = new ApiResponse();

            try
            {
                var entity = Uow.ProductRepository.Get(new Product(id));

                if (entity == null)
                {
                    result.DidError = true;

                    result.ErrorMessage = String.Format("There isn't a record with id: {0}", id);
                }
                else
                {
                    entity.ProductName = value.ProductName;
                    entity.SupplierID = value.SupplierID;
                    entity.CategoryID = value.CategoryID;
                    entity.QuantityPerUnit = value.QuantityPerUnit;

                    Uow.ProductRepository.Update(entity);

                    await Uow.CommitChangesAsync();

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
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            var result = new ApiResponse();

            try
            {
                var entity = Uow.ProductRepository.Get(new Product(id));

                if (entity == null)
                {
                    result.DidError = true;

                    result.ErrorMessage = String.Format("There isn't a record with id: {0}", id);
                }
                else
                {
                    Uow.ProductRepository.Remove(entity);

                    await Uow.CommitChangesAsync();

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
