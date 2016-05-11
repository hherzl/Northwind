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
    public class ProductController : ApiController
    {
        protected ISalesBusinessObject BusinessObject;

        public ProductController(IBusinessObjectService service)
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

        // GET: api/Product
        public async Task<HttpResponseMessage> Get(String productName, Int32? supplierID, Int32? categoryID)
        {
            var response = new ComposedViewModelResponse<ProductDetailViewModel>() as IComposedViewModelResponse<ProductDetailViewModel>;

            try
            {
                var task = await BusinessObject.GetProductsDetails(productName, supplierID, categoryID);

                response.Model = task.Select(item => new ProductDetailViewModel(item)).ToList();
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // GET: api/Product/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new SingleViewModelResponse<Product>() as ISingleViewModelResponse<Product>;

            try
            {
                response.Model = await BusinessObject.GetProduct(new Product(id));
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // POST: api/Product
        public async Task<HttpResponseMessage> Post([FromBody]Product value)
        {
            var response = new SingleViewModelResponse<Product>() as ISingleViewModelResponse<Product>;

            try
            {
                await BusinessObject.CreateProduct(value);

                response.Model = value;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // PUT: api/Product/5
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]Product value)
        {
            var response = new SingleViewModelResponse<Product>() as ISingleViewModelResponse<Product>;

            try
            {
                var entity = await BusinessObject.UpdateProduct(value);

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
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // DELETE: api/Product/5
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            var response = new SingleViewModelResponse<Product>() as ISingleViewModelResponse<Product>;

            try
            {
                var entity = await BusinessObject.DeleteProduct(new Product(id));

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
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }
    }
}
