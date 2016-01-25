using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.EntityLayer;
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
            var response = new ComposedCustomerResponse();

            try
            {
                var task = await BusinessObject.GetCustomers();

                response.Model = task.ToList();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // GET: api/Customer/5
        public async Task<HttpResponseMessage> Get(String id)
        {
            var response = new SingleCustomerResponse();

            try
            {
                response.Model = await BusinessObject.GetCustomer(new Customer(id));
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // POST: api/Customer
        public async Task<HttpResponseMessage> Post([FromBody]Customer value)
        {
            var response = new SingleCustomerResponse();

            try
            {
                value.CustomerID = value.CompanyName.Substring(0, 5).ToUpper();

                await BusinessObject.CreateCustomer(value);

                response.Model = value;

                response.Message = "The data was saved successfully!";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // PUT: api/Customer/5
        public async Task<HttpResponseMessage> Put(String id, [FromBody]Customer value)
        {
            var response = new SingleCustomerResponse();

            try
            {
                var entity = await BusinessObject.UpdateCustomer(value);

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

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // DELETE: api/Customer/5
        public async Task<HttpResponseMessage> Delete(String id)
        {
            var response = new SingleCustomerResponse();

            try
            {
                var entity = await BusinessObject.DeleteCustomer(new Customer(id));

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

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
