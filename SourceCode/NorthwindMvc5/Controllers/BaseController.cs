using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace NorthwindMvc5.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {

        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, Object state)
        {
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["culture"] as String ?? LanguageInfo.DefaultCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");

            return base.BeginExecuteCore(callback, state);
        }
    }
}
