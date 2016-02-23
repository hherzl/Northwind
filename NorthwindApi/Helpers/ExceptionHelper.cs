using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using NorthwindApi.Models;

namespace NorthwindApi.Helpers
{
    public static class ExceptionHelper
    {
        private static void WriteToLog(String path, ErrorLog errorLog)
        {
            var log = new StringBuilder();

            log.AppendLine(String.Format("Fecha: {0}", errorLog.Date));
            log.AppendLine(String.Format("Usuario: {0}", errorLog.User));

            if (errorLog.UrlReferrer != null)
            {
                log.AppendLine(String.Format("Url referida: {0}", errorLog.UrlReferrer));
            }

            log.AppendLine(String.Format("Url: {0}", errorLog.Url));

            log.AppendLine(String.Format("Navegador: {0}", errorLog.Browser));
            log.AppendLine(String.Format("Versión de navegador: {0}", errorLog.BrowserVersion));

            foreach (var m in errorLog.ValidationMessages)
            {
                log.AppendLine(String.Format(" * {0}", m));
            }

            log.AppendLine(String.Format("Excepción: {0}", errorLog.Exception.ToString()));
            log.AppendLine("");
            log.AppendLine("*****************************************************************************************************");
            log.AppendLine("");

            TextFileHelper.Append(path, log.ToString(), Encoding.UTF8);
        }

        private static void SaveToLog(String path, ErrorLog errorLog)
        {
            var ctx = new ErrorLogDbContext();

            ctx.ErrorLog.Add(errorLog);

            ctx.SaveChanges();

            var list = ErrorLogHelper.GetData(path);

            list.Add(errorLog);

            ErrorLogHelper.SaveData(list, path);
        }

        public static void Publish(Exception ex)
        {
            //var httpContext = HttpContext.Current;

            //var errorLog = new ErrorLog();

            //errorLog.Date = DateTime.Now;
            //errorLog.User = httpContext.User.Identity.Name;

            //if (HttpContext.Current.Request.UrlReferrer != null)
            //{
            //    errorLog.UrlReferrer = httpContext.Request.UrlReferrer.ToString();
            //}

            //errorLog.Url = httpContext.Request.Url.ToString();

            //errorLog.Browser = httpContext.Request.Browser.Browser;
            //errorLog.BrowserVersion = httpContext.Request.Browser.Version;

            //var dbEntityValidationException = ex as DbEntityValidationException;

            //if (dbEntityValidationException != null)
            //{
            //    foreach (var validationError in dbEntityValidationException.EntityValidationErrors.SelectMany(item => item.ValidationErrors))
            //    {
            //        errorLog.ValidationMessages.Add(String.Format("{0}: {1}", validationError.PropertyName, validationError.ErrorMessage));
            //    }
            //}

            //errorLog.Exception = ex.ToString();

            //SaveToLog(httpContext.Server.MapPath(AppSettingsHelper.JsonErrorLogPath), errorLog);

            //WriteToLog(httpContext.Server.MapPath(AppSettingsHelper.ErrorLogPath), errorLog);
        }

        public static String GetMessage(Exception ex)
        {
            if (ex is DbUpdateException)
            {
                return ex.InnerException.InnerException.Message;
            }

            return String.Empty;
        }
    }
}
