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
    public class CustomerController : ApiController
    {
        protected ISalesUow Uow;

        public CustomerController(IUowService service)
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

        // GET: api/Customer
        public async Task<HttpResponseMessage> Get()
        {
            var result = new ApiResponse();

            try
            {
                result.Model = await Task.Run(() =>
                {
                    return Uow
                        .CustomerRepository
                        .GetAll()
                        .OrderByDescending(item => item.CustomerID)
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

        // GET: api/Customer/5
        public async Task<HttpResponseMessage> Get(String id)
        {
            var result = new ApiResponse();

            try
            {
                result.Model = await Task.Run(() =>
                {
                    return Uow
                        .CustomerRepository
                        .Get(new Customer(id));
                });
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/Customer
        public async Task<HttpResponseMessage> Post([FromBody]Customer value)
        {
            var result = new ApiResponse();

            try
            {

                value.CustomerID = value.CompanyName.Substring(0, 5).ToUpper();

                Uow.CustomerRepository.Add(value);

                await Uow.CommitChangesAsync();

                result.Message = "The data was saved successfully!";
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // PUT: api/Customer/5
        public async Task<HttpResponseMessage> Put(String id, [FromBody]Customer value)
        {
            var entity = Uow.CustomerRepository.Get(new Customer(id));

            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Error");
            }

            entity.CompanyName = value.CompanyName;
            entity.ContactName = value.ContactName;
            entity.ContactTitle = value.ContactTitle;
            entity.Address = value.Address;
            entity.City = value.City;
            entity.Region = value.Region;
            entity.PostalCode = value.PostalCode;
            entity.Country = value.Country;
            entity.Phone = value.Phone;
            entity.Fax = value.Fax;

            var result = new ApiResponse();

            try
            {
                Uow.CustomerRepository.Update(entity);

                await Uow.CommitChangesAsync();

                result.Message = "The changes was saved successfully!";
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // DELETE: api/Customer/5
        public async Task<HttpResponseMessage> Delete(String id)
        {
            var entity = Uow.CustomerRepository.Get(new Customer(id));

            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Error");
            }

            var result = new ApiResponse();

            try
            {
                Uow.CustomerRepository.Remove(entity);

                await Uow.CommitChangesAsync();
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Delete was successfully!");
        }
    }
}
