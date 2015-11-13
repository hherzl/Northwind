using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace NorthwindApi.Filters
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            //Log Critical errors
            Debug.WriteLine(context.Exception);

            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An error occurred, please try again or contact the administrator."),
                ReasonPhrase = "Critical Exception"
            });
        }
    }
}
