using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.EntityLayer;
using NorthwindApi.Helpers;
using NorthwindApi.Responses;

namespace NorthwindApi.Controllers
{
    public partial class AdministrationController : ApiController
    {
        // GET: api/Customer
        [HttpGet]
        [Route("Customer")]
        public async Task<HttpResponseMessage> GetCustomers()
        {
            var response = new ComposedModelResponse<Customer>() as IComposedModelResponse<Customer>;

            try
            {
                var task = await Task.Run(() => { return BusinessObject.GetCustomers(); });

                response.Model = task.ToList();
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // GET: api/Customer/5
        [HttpGet]
        [Route("Customer")]
        public async Task<HttpResponseMessage> GetCustomer(String id)
        {
            var response = new SingleModelResponse<Customer>() as ISingleModelResponse<Customer>;

            try
            {
                response.Model = await Task.Run(() => { return BusinessObject.GetCustomer(new Customer(id)); });
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // POST: api/Customer
        [HttpPost]
        [Route("Customer")]
        public async Task<HttpResponseMessage> CreateCustomer([FromBody]Customer value)
        {
            var response = new SingleModelResponse<Customer>() as ISingleModelResponse<Customer>;

            try
            {
                response.Model = await Task.Run(() => { return BusinessObject.CreateCustomer(value); }); ;

                response.Message = "The data was saved successfully!";
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // PUT: api/Customer/5
        [HttpPut]
        [Route("Customer")]
        public async Task<HttpResponseMessage> UpdateCustomer(String id, [FromBody]Customer value)
        {
            var response = new SingleModelResponse<Customer>() as ISingleModelResponse<Customer>;

            try
            {
                var entity = await Task.Run(() => { return BusinessObject.UpdateCustomer(value); });

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

        // DELETE: api/Customer/5
        [HttpDelete]
        [Route("Customer")]
        public async Task<HttpResponseMessage> DeleteCustomer(String id)
        {
            var response = new SingleModelResponse<Customer>() as ISingleModelResponse<Customer>;

            try
            {
                var entity = await Task.Run(() => { return BusinessObject.DeleteCustomer(new Customer(id)); });

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
