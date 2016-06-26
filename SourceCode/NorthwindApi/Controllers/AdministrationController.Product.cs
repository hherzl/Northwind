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
        // GET: api/Product
        [HttpGet]
        [Route("Product")]
        public async Task<HttpResponseMessage> GetProducts(String productName, Int32? supplierID, Int32? categoryID)
        {
            var response = new ComposedModelResponse<ProductDetailViewModel>() as IComposedModelResponse<ProductDetailViewModel>;

            try
            {
                response.Model = await Task.Run(() =>
                {
                    return BusinessObject.GetProductsDetails(supplierID, categoryID, productName).Select(item => new ProductDetailViewModel(item)).ToList();
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

        // GET: api/Product/5
        [HttpGet]
        [Route("Product")]
        public async Task<HttpResponseMessage> GetProduct(Int32 id)
        {
            var response = new SingleModelResponse<Product>() as ISingleModelResponse<Product>;

            try
            {
                response.Model = await Task.Run(() =>
                    {
                        return BusinessObject.GetProduct(new Product(id));
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

        // POST: api/Product
        [HttpPost]
        [Route("Product")]
        public async Task<HttpResponseMessage> CreateProduct([FromBody]Product value)
        {
            var response = new SingleModelResponse<Product>() as ISingleModelResponse<Product>;

            try
            {
                response.Model = await Task.Run(() =>
                    {
                        return BusinessObject.CreateProduct(value);
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

        // PUT: api/Product/5
        [HttpPut]
        [Route("Product")]
        public async Task<HttpResponseMessage> UpdateProduct(Int32 id, [FromBody]Product value)
        {
            var response = new SingleModelResponse<Product>() as ISingleModelResponse<Product>;

            try
            {
                var entity = await Task.Run(() =>
                    {
                        return BusinessObject.UpdateProduct(value);
                    });

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

        // DELETE: api/Product/5
        [HttpDelete]
        [Route("Product")]
        public async Task<HttpResponseMessage> DeleteProduct(Int32 id)
        {
            var response = new SingleModelResponse<Product>() as ISingleModelResponse<Product>;

            try
            {
                var entity = await Task.Run(() =>
                    {
                        return BusinessObject.DeleteProduct(new Product(id));
                    });

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
