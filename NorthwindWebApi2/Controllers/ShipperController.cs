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
    public class ShipperController : ApiController
    {
        protected ISalesUow Uow;

        public ShipperController(IUowService service)
        {
            Uow = service.GetSalesUow();
        }

        protected override void Dispose(Boolean disposing)
        {
            Uow.Dispose();

            base.Dispose(disposing);
        }

        // GET: api/Shipper
        public HttpResponseMessage Get()
        {
            var list = Uow.ShipperRepository.GetAll().OrderByDescending(item => item.ShipperID).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        // GET: api/Shipper/5
        public HttpResponseMessage Get(Int32 id)
        {
            var entity = Uow.ShipperRepository.Get(new Shipper() { ShipperID = id });

            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        // POST: api/Shipper
        public void Post([FromBody]Shipper value)
        {
            Uow.ShipperRepository.Add(value);

            Uow.CommitChanges();
        }

        // PUT: api/Shipper/5
        public HttpResponseMessage Put(Int32 id, [FromBody]Shipper value)
        {
            var entity = Uow.ShipperRepository.Get(new Shipper() { ShipperID = id });

            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Error");
            }

            entity.CompanyName = value.CompanyName;
            entity.Phone = value.Phone;

            Uow.ShipperRepository.Update(entity);

            Uow.CommitChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Update was successfully!");
        }

        // DELETE: api/Shipper/5
        public HttpResponseMessage Delete(Int32 id)
        {
            var entity = Uow.ShipperRepository.Get(new Shipper() { ShipperID = id });

            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Error");
            }

            Uow.ShipperRepository.Remove(entity);

            Uow.CommitChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Delete was successfully!");
        }
    }
}
