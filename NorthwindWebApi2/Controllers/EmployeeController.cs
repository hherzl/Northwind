using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;
using NorthwindWebApi2.Models;
using NorthwindWebApi2.Services;

namespace NorthwindWebApi2.Controllers
{
    public class EmployeeController : ApiController
    {
        protected ISalesUow Uow;

        public EmployeeController(IUowService service)
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

        // GET: api/Employee
        public async Task<HttpResponseMessage> Get()
        {
            var result = new ApiResponse();

            try
            {
                result.Model = await Task.Run(() =>
                {
                    return Uow.EmployeeRepository.GetAll().Select(item =>
                        new EmployeeDetail()
                        {
                            EmployeeID = item.EmployeeID,
                            FullName = item.FirstName + " " + item.LastName,
                            Title = item.Title,
                            TitleOfCourtesy = item.TitleOfCourtesy
                        }).ToList();
                });
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/Employee/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var result = new ApiResponse();

            try
            {
                result.Model = await Task.Run(() =>
                {
                    return Uow.EmployeeRepository.Get(new Employee(id));
                });
            }
            catch (Exception ex)
            {
                result.DidError = true;

                result.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/Employee
        public void Post([FromBody]Employee value)
        {

        }

        // PUT: api/Employee/5
        public void Put(Int32 id, [FromBody]Employee value)
        {

        }

        // DELETE: api/Employee/5
        public void Delete(Int32 id)
        {

        }
    }
}
