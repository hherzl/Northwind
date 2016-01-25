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
    public class RegionController : ApiController
    {
        protected ISalesUow Uow;

        public RegionController(IUowService service)
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

        // GET: api/Region
        public async Task<HttpResponseMessage> Get()
        {
            var response = new ComposedRegionResponse() as IComposedViewModelResponse<Region>;

            var foo = Uow.RegionRepository.GetAll().ToList();

            try
            {
                response.Model = await Task.Run(() =>
                {
                    return Uow
                        .RegionRepository
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

        // GET: api/Region/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new SingleRegionResponse() as ISingleViewModelResponse<Region>;

            try
            {
                response.Model = await Task.Run(() =>
                {
                    return Uow
                        .RegionRepository
                        .Get(new Region(id));
                });

                if (response.Model == null)
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

        // POST: api/Region
        public async Task<HttpResponseMessage> Post([FromBody]Region value)
        {
            var response = new SingleRegionResponse() as ISingleViewModelResponse<Region>;

            try
            {
                Uow.RegionRepository.Add(value);

                if (await Uow.CommitChangesAsync() > 0)
                {
                    response.Message = "Record added successfully";
                    response.Model = value;
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

        // PUT: api/Region/5
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]Region value)
        {
            var response = new SingleRegionResponse() as ISingleViewModelResponse<Region>;

            try
            {
                var entity = Uow.RegionRepository.Get(new Region(id));

                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                entity.RegionDescription = value.RegionDescription;

                Uow.RegionRepository.Update(entity);

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

        // DELETE: api/Region/5
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            var response = new SingleRegionResponse() as ISingleViewModelResponse<Region>;

            try
            {
                var entity = Uow.RegionRepository.Get(new Region(id));

                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                Uow.RegionRepository.Remove(entity);

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
