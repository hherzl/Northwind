using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using NorthwindApi.Models;

namespace NorthwindApi.Controllers
{
    public class ErrorLogController : ApiController
    {
        protected ErrorLogDbContext ErrorLogDbContext;

        public ErrorLogController(ErrorLogDbContext dbContext)
        {
            ErrorLogDbContext = dbContext;
        }

        public async Task<HttpResponseMessage> Get()
        {
            var model = await Task.Run(() =>
            {
                return ErrorLogDbContext
                    .ErrorLog
                    .OrderByDescending(item => item.ID)
                    .Select(item => new { ID = item.ID, Date = item.Date, User = item.User, Url = item.Url, Browser = item.Browser, BrowserVersion = item.BrowserVersion })
                    .ToList();
            });

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var model = await Task.Run(() =>
            {
                return ErrorLogDbContext.ErrorLog.FirstOrDefault(item => item.ID == id);
            });

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
    }
}
