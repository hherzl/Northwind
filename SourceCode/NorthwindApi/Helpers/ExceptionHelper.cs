using System;
using Northwind.Core.Helpers;
using NorthwindApi.Models;

namespace NorthwindApi.Helpers
{
    public static class ExceptionHelper
    {
        public static void Publish(Exception ex)
        {
            var errorLog = new ErrorLog();

            errorLog.Date = DateTime.Now;

            var httpContext = System.Web.HttpContext.Current;

            if (httpContext != null)
            {
                errorLog.User = httpContext.User.Identity.Name;

                if (httpContext.Request.UrlReferrer != null)
                {
                    errorLog.UrlReferrer = httpContext.Request.UrlReferrer.ToString();
                }

                errorLog.Url = httpContext.Request.Url.ToString();

                errorLog.Browser = httpContext.Request.Browser.Browser;
                errorLog.BrowserVersion = httpContext.Request.Browser.Version;
            }

            foreach (var validationError in ex.GetEntityValidationErrors())
            {
                errorLog.ValidationMessages.Add(String.Format("{0}: {1}", validationError.PropertyName, validationError.ErrorMessage));
            }

            errorLog.Exception = ex.ToString();

            var dbContext = new ErrorLogDbContext();

            dbContext.AddErrorLog(errorLog);
        }
    }
}
