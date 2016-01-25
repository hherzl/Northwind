using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.EntityLayer;
using NorthwindApi.Responses;
using NorthwindApi.Services;
using NorthwindApi.ViewModels;

namespace NorthwindApi.Controllers
{
    public class EmployeeController : ApiController
    {
        protected ISalesBusinessObject BusinessObject;

        public EmployeeController(IUowService service)
        {
            BusinessObject = service.GetSalesBusinessObject();
        }

        protected override void Dispose(Boolean disposing)
        {
            if (BusinessObject != null)
            {
                BusinessObject.Release();
            }

            base.Dispose(disposing);
        }

        // GET: api/Employee
        public async Task<HttpResponseMessage> Get()
        {
            var response = new ComposedEmployeeDetailResponse();

            try
            {
                var task = await BusinessObject.GetEmployees();

                response.Model = task.Select(item => new EmployeeDetailViewModel(item)).ToList();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // GET: api/Employee/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new SingleEmployeeResponse();

            try
            {
                response.Model = await BusinessObject.GetEmployee(new Employee(id));
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
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
