using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET: api/Shipper
        public async Task<IEnumerable<Shipper>> Get()
        {
            return await Task.Run(() =>
                {
                    return Uow
                        .ShipperRepository
                        .GetAll()
                        .ToList();
                });
        }

        // GET: api/Shipper/5
        public async Task<Shipper> Get(Int32 id)
        {
            return await Task.Run(() =>
                {
                    return Uow
                        .ShipperRepository
                        .Get(new Shipper(id));
                });
        }

        // POST: api/Shipper
        public void Post([FromBody]Shipper value)
        {
        }

        // PUT: api/Shipper/5
        public void Put(Int32 id, [FromBody]Shipper value)
        {
        }

        // DELETE: api/Shipper/5
        public void Delete(Int32 id)
        {
        }
    }
}
