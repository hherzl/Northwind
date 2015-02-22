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
            if (Uow != null)
            {
                Uow.Dispose();
            }

            base.Dispose(disposing);
        }

        // GET: api/Shipper
        public HttpResponseMessage Get()
        {
            var result = new ApiResult();

            try
            {
                result.Model = Uow.ShipperRepository.GetAll().OrderByDescending(item => item.ShipperID).ToList();
            }
            catch (Exception ex)
            {
                result.DidError = true;
                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/Shipper/5
        public HttpResponseMessage Get(Int32 id)
        {
            var result = new ApiResult();

            try
            {
                result.Model = Uow.ShipperRepository.Get(new Shipper() { ShipperID = id });
            }
            catch (Exception ex)
            {
                result.DidError = true;
                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/Shipper
        public HttpResponseMessage Post([FromBody]Shipper value)
        {
            var result = new ApiResult();

            try
            {
                Uow.ShipperRepository.Add(value);

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

        // PUT: api/Shipper/5
        public HttpResponseMessage Put(Int32 id, [FromBody]Shipper value)
        {
            var entity = Uow.ShipperRepository.Get(new Shipper() { ShipperID = id });

            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Error");
            }

            var result = new ApiResult();

            try
            {
                entity.CompanyName = value.CompanyName;
                entity.Phone = value.Phone;

                Uow.ShipperRepository.Update(entity);

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

        // DELETE: api/Shipper/5
        public HttpResponseMessage Delete(Int32 id)
        {
            var entity = Uow.ShipperRepository.Get(new Shipper() { ShipperID = id });

            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Error");
            }

            var result = new ApiResult();

            try
            {
                Uow.ShipperRepository.Remove(entity);

                Uow.CommitChanges();

                result.Model = entity;
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
