using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.EntityLayer;
using NorthwindApi.Helpers;
using NorthwindApi.Responses;
using NorthwindApi.ViewModels;

namespace NorthwindApi.Controllers
{
    public partial class AdministrationController : ApiController
    {
        // GET: api/Employee
        [HttpGet]
        [Route("Employee")]
        public async Task<HttpResponseMessage> GetEmployees()
        {
            var response = new ComposedModelResponse<EmployeeDetailViewModel>() as IComposedModelResponse<EmployeeDetailViewModel>;

            try
            {
                response.Model = await Task.Run(() =>
                {
                    return BusinessObject.GetEmployees().Select(item => new EmployeeDetailViewModel(item)).ToList();
                });
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
        [HttpGet]
        [Route("Employee")]
        public async Task<HttpResponseMessage> GetEmployee(Int32 id)
        {
            var response = new SingleModelResponse<Employee>() as ISingleModelResponse<Employee>;

            try
            {
                response.Model = await Task.Run(() =>
                    {
                        return BusinessObject.GetEmployee(new Employee(id));
                    });
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
