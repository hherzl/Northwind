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
    public class ShipperController : ApiController
    {
        protected ISalesUow Uow;

        public ShipperController(IBusinessObjectService service)
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
        public async Task<HttpResponseMessage> Get()
        {
            var response = new ApiResponse();

            try
            {
                response.Model = await Task.Run(() =>
                {
                    return Uow
                        .ShipperRepository
                        .GetAll()
                        .ToList();
                });
            }
            catch (Exception ex)
            {
                response.DidError = true;

                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // GET: api/Shipper/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new ApiResponse();

            try
            {
                response.Model = await Task.Run(() =>
                {
                    return Uow.ShipperRepository.Get(new Shipper(id));
                });
            }
            catch (Exception ex)
            {
                response.DidError = true;

                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // POST: api/Shipper
        public async Task<HttpResponseMessage> Post([FromBody]Shipper value)
        {
            var response = new ApiResponse();

            try
            {
                Uow.ShipperRepository.Add(value);

                await Uow.CommitChangesAsync();

                response.Model = value;
            }
            catch (Exception ex)
            {
                response.DidError = true;

                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // PUT: api/Shipper/5
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]Shipper value)
        {
            var response = new ApiResponse();

            try
            {
                var entity = Uow.ShipperRepository.Get(new Shipper(id));

                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Error");
                }

                entity.CompanyName = value.CompanyName;
                entity.Phone = value.Phone;

                Uow.ShipperRepository.Update(entity);

                await Uow.CommitChangesAsync();

                response.Model = value;
            }
            catch (Exception ex)
            {
                response.DidError = true;

                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // DELETE: api/Shipper/5
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            var response = new ApiResponse();

            try
            {
                var entity = Uow.ShipperRepository.Get(new Shipper(id));

                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Error");
                }

                Uow.ShipperRepository.Remove(entity);

                await Uow.CommitChangesAsync();

                response.Model = entity;
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
