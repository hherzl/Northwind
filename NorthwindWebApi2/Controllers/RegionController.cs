using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.DataLayer;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;
using NorthwindWebApi2.Models;
using NorthwindWebApi2.Services;

namespace NorthwindWebApi2.Controllers
{
    public class RegionController : ApiController
    {
        protected ISalesUow Uow;

        public RegionController(IBusinessObjectService service)
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
                result.Model = await Task.Run(() =>
                    {
                        return Uow
                            .RegionRepository
                            .GetAll()
                            .ToList();
                    });
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/Region/5
        public string Get(Int32 id)
        {
            return "value";
        }

        // POST: api/Region
        public void Post([FromBody]Region value)
        {

        }

        // PUT: api/Region/5
        public void Put(Int32 id, [FromBody]Region value)
        {

        }

        // DELETE: api/Region/5
        public void Delete(Int32 id)
        {

        }
    }
}
