using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Northwind.Core.BusinessLayer;
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
        public HttpResponseMessage Get()
        {
            var result = new ApiResult();

            try
            {
                result.Model = Uow.SupplierRepository.GetAll().OrderByDescending(item => item.SupplierID).ToList();
            }
            catch (Exception ex)
            {
                result.DidError = true;
                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/Supplier/5
        public HttpResponseMessage Get(Int32 id)
        {
            var result = new ApiResult();

            try
            {
                result.Model = Uow.SupplierRepository.Get(new Supplier { SupplierID = id });
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/Supplier
        public HttpResponseMessage Post([FromBody]Supplier value)
        {
            var result = new ApiResult();

            try
            {
                Uow.SupplierRepository.Add(value);

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

        // PUT: api/Supplier/5
        public HttpResponseMessage Put(Int32 id, [FromBody]Supplier value)
        {
            var entity = Uow.SupplierRepository.Get(new Supplier { SupplierID = id });

            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Error");
            }

            var result = new ApiResult();

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

                Uow.CommitChanges();
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // DELETE: api/Supplier/5
        public HttpResponseMessage Delete(Int32 id)
        {
            var entity = Uow.SupplierRepository.Get(new Supplier { SupplierID = id });

            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Error");
            }

            Uow.SupplierRepository.Remove(entity);

            Uow.CommitChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Delete was successfully!");
        }
    }
}
