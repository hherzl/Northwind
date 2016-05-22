using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.EntityLayer;
using NorthwindApi.Helpers;
using NorthwindApi.Responses;
using NorthwindApi.Services;
using NorthwindApi.ViewModels;

namespace NorthwindApi.Controllers
{
    public class EmployeeController : ApiController
    {
        protected ISalesBusinessObject BusinessObject;

        public EmployeeController(IBusinessObjectService service)
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
            var response = new ComposedModelResponse<EmployeeDetailViewModel>() as IComposedModelResponse<EmployeeDetailViewModel>;

            try
            {
                var task = await BusinessObject.GetEmployees();

                response.Model = task.Select(item => new EmployeeDetailViewModel(item)).ToList();
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // GET: api/Employee/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new SingleModelResponse<Employee>() as ISingleModelResponse<Employee>;

            try
            {
                response.Model = await BusinessObject.GetEmployee(new Employee(id));
            }
            catch (Exception ex)
            {
                ExceptionHelper.Publish(ex);

                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }
    }
}
