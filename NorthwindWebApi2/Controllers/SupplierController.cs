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
    public class SupplierController : ApiController
    {
        protected ISalesUow Uow;

        public SupplierController(IUowService service)
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

        // GET: api/Supplier
        public async Task<HttpResponseMessage> Get()
        {
            var result = new ApiResponse();

            try
            {
                result.Model = await Task.Run(() =>
                    {
                        return Uow
                            .SupplierRepository
                            .GetAll()
                            .OrderByDescending(item => item.SupplierID)
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

        // GET: api/Supplier/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var result = new ApiResponse();

            try
            {
                result.Model = await Task.Run(() =>
                {
                    return Uow.SupplierRepository.Get(new Supplier(id));
                });
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/Supplier
        public async Task<HttpResponseMessage> Post([FromBody]Supplier value)
        {
            var result = new ApiResponse();

            try
            {
                Uow.SupplierRepository.Add(value);

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

        // PUT: api/Supplier/5
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]Supplier value)
        {
            var entity = Uow.SupplierRepository.Get(new Supplier(id));

            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Error");
            }

            var result = new ApiResponse();

            try
            {
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
                entity.HomePage = value.HomePage;

                Uow.SupplierRepository.Update(entity);

                await Uow.CommitChangesAsync();
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // DELETE: api/Supplier/5
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            var result = new ApiResponse();

            try
            {
                var entity = Uow.SupplierRepository.Get(new Supplier(id));

                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Error");
                }

                Uow.SupplierRepository.Remove(entity);

                await Uow.CommitChangesAsync();

                result.Message = "Delete was successfully!";
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
