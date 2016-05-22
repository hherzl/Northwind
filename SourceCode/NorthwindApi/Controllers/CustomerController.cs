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

namespace NorthwindApi.Controllers
{
    public class CustomerController : ApiController
    {
        protected ISalesBusinessObject BusinessObject;

        public CustomerController(IBusinessObjectService service)
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

        // GET: api/Customer
        public async Task<HttpResponseMessage> Get()
        {
            var response = new ComposedModelResponse<Customer>() as IComposedModelResponse<Customer>;

            try
            {
                var task = await BusinessObject.GetCustomers();

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
        public async Task<HttpResponseMessage> Get(String id)
        {
            var response = new SingleModelResponse<Customer>() as ISingleModelResponse<Customer>;

            try
            {
                response.Model = await BusinessObject.GetCustomer(new Customer(id));
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
        public async Task<HttpResponseMessage> Post([FromBody]Customer value)
        {
            var response = new SingleModelResponse<Customer>() as ISingleModelResponse<Customer>;

            try
            {
                value.CustomerID = value.CompanyName.Substring(0, 5).ToUpper();

                await BusinessObject.CreateCustomer(value);

                response.Model = value;

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
        public async Task<HttpResponseMessage> Put(String id, [FromBody]Customer value)
        {
            var response = new SingleModelResponse<Customer>() as ISingleModelResponse<Customer>;

            try
            {
                var entity = await BusinessObject.UpdateCustomer(value);

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
        public async Task<HttpResponseMessage> Delete(String id)
        {
            var response = new SingleModelResponse<Customer>() as ISingleModelResponse<Customer>;

            try
            {
                var entity = await BusinessObject.DeleteCustomer(new Customer(id));

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
