using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;
using NorthwindApi.Helpers;
using NorthwindApi.Responses;
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
            var response = new ComposedShipperResponse() as IComposedShipperResponse;

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
                ExceptionHelper.Publish(ex);

                response.ErrorMessage = ex.Message;
                response.DidError = true;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // GET: api/Shipper/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new SingleShipperResponse() as ISingleShipperResponse;

            try
            {
                response.Single = await Task.Run(() =>
                {
                    return Uow
                        .ShipperRepository
                        .Get(new Shipper(id));
                });

                if (response.Single == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.ErrorMessage = ex.Message;
                response.DidError = true;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // POST: api/Shipper
        public async Task<HttpResponseMessage> Post([FromBody]Shipper value)
        {
            var response = new SingleShipperResponse() as ISingleShipperResponse;

            try
            {
                Uow.ShipperRepository.Add(value);

                if (await Uow.CommitChangesAsync() > 0)
                {
                    response.Message = "Record added successfully";
                    response.Value = value.ShipperID;
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.ErrorMessage = ex.Message;
                response.DidError = true;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // PUT: api/Shipper/5
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]Shipper value)
        {
            var response = new SingleShipperResponse() as ISingleShipperResponse;

            try
            {
                var entity = Uow.ShipperRepository.Get(new Shipper(id));

                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                entity.CompanyName = value.CompanyName;
                entity.Phone = value.Phone;

                Uow.ShipperRepository.Update(entity);

                if (await Uow.CommitChangesAsync() > 0)
                {
                    response.Message = "Record updated successfully";
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.ErrorMessage = ex.Message;
                response.DidError = true;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // DELETE: api/Shipper/5
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            var response = new SingleShipperResponse() as ISingleShipperResponse;

            try
            {
                var entity = Uow.ShipperRepository.Get(new Shipper(id));

                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                Uow.ShipperRepository.Remove(entity);

                if (await Uow.CommitChangesAsync() > 0)
                {
                    response.Message = "Record deleted successfully";
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.ErrorMessage = ex.Message;
                response.DidError = true;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
