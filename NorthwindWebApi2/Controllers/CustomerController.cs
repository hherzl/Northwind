using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Northwind.Core.BusinessLayer;
using Northwind.Core.PocoLayer;
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
            Uow.Dispose();

            base.Dispose(disposing);}

        // GET: api/Customer
        public HttpResponseMessage Get()
        {
            var list = Uow.CustomerRepository.GetAll().ToList();

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        // GET: api/Customer/5
        public HttpResponseMessage Get(String id)
        {
            var entity = Uow.CustomerRepository.Get(new Customer { CustomerID = id });

            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        // POST: api/Customer
        public void Post([FromBody]Customer value)
        {
            value.CustomerID = value.CompanyName.Substring(0, 5).ToUpper();
            Uow.CustomerRepository.Add(value);
            Uow.CommitChanges();
        }

        // PUT: api/Customer/5
        public HttpResponseMessage Put(String id, [FromBody]Customer value)
        {
            var entity = Uow.CustomerRepository.Get(new Customer {CustomerID = id});

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
            
            Uow.CustomerRepository.Update(entity);
            Uow.CommitChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Update was successfully!");

        }

        // DELETE: api/Customer/5
        public HttpResponseMessage Delete(String id)
        {
            var entity = Uow.CustomerRepository.Get(new Customer {CustomerID = id});

            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Error");
            }
        
            Uow.CustomerRepository.Remove(entity);

            Uow.CommitChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Delete was successfully!");

        }
    }
}
