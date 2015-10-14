using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;
using NorthwindApi.Services;

namespace NorthwindApi.Controllers
{
    public class ShipperController : ApiController
    {
        protected ISalesUow Uow;

        public ShipperController(IUowService service)
        {
            Uow = service.GetSalesUow();
        }

        protected override void Dispose(bool disposing)
        {
            if (Uow != null)
            {
                Uow.Dispose();
            }

            base.Dispose(disposing);
        }

        // GET: api/Shipper
        public async Task<HttpResponseMessage> Get()
        {
            var list = await Task.Run(() =>
                {
                    return Uow
                        .ShipperRepository
                        .GetAll()
                        .ToList();
                });

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        // GET: api/Shipper/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var entity = await Task.Run(() =>
                {
                    return Uow
                        .ShipperRepository
                        .Get(new Shipper(id));
                });

            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        // POST: api/Shipper
        public async Task<HttpResponseMessage> Post([FromBody]Shipper value)
        {
            Uow.ShipperRepository.Add(value);

            await Uow.CommitChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, value.ShipperID);
        }

        // PUT: api/Shipper/5
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]Shipper value)
        {
            var entity = Uow.ShipperRepository.Get(new Shipper(id));

            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            entity.CompanyName = value.CompanyName;
            entity.Phone = value.Phone;

            Uow.ShipperRepository.Update(entity);

            await Uow.CommitChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE: api/Shipper/5
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            var entity = Uow.ShipperRepository.Get(new Shipper(id));

            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            Uow.ShipperRepository.Remove(entity);

            await Uow.CommitChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
