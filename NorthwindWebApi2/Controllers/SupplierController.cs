using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Northwind.Core.BusinessLayer;
using Northwind.Core.PocoLayer;
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
            Uow.Dispose();

            base.Dispose(disposing);
        }

        // GET: api/Supplier
        public HttpResponseMessage Get()
        {
            var list = Uow.SupplierRepository.GetAll().ToList();

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        // GET: api/Supplier/5
        public HttpResponseMessage Get(Int32 id)
        {
            var entity = Uow.SupplierRepository.Get(new Supplier { SupplierID = id });

            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        // POST: api/Supplier
        public void Post([FromBody]Supplier value)
        {
            Uow.SupplierRepository.Add(value);
            Uow.CommitChanges();
        }

        // PUT: api/Supplier/5
        public HttpResponseMessage Put(Int32 id, [FromBody]Supplier value)
        {
            var entity = Uow.SupplierRepository.Get(new Supplier {SupplierID = id});

            if (entity ==null)
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
            entity.HomePage = value.HomePage;

            Uow.SupplierRepository.Update(entity);
            Uow.CommitChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Update was successfully!");
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
