using System;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.DataLayer;
using Northwind.Core.DataLayer.Contracts;
using NorthwindWebApi2.Models;
using NorthwindWebApi2.Services;

namespace NorthwindWebApi2.Controllers
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
            var result = new ApiResponse();

            try
            {
                result.Model = await Uow.RegionRepository
                    .GetAll()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/Region/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Region
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Region/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Region/5
        public void Delete(int id)
        {
        }
    }
}
