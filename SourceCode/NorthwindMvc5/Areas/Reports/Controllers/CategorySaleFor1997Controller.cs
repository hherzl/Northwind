using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using Northwind.Core.DataLayer.Contracts;
using NorthwindMvc5.Areas.Reports.Models;
using NorthwindMvc5.Extensions;
using NorthwindMvc5.Services;

namespace NorthwindMvc5.Areas.Reports.Controllers
{
    public class CategorySaleFor1997Controller : Controller
    {
        protected IReportsUow Uow;

        public CategorySaleFor1997Controller(IUowService service)
        {
            Uow = service.GetReportsUow();
        }

        protected override void Dispose(Boolean disposing)
        {
            if (Uow != null)
            {
                Uow.Dispose();
            }

            base.Dispose(disposing);
        }

        // GET: Reports/CategorySaleFor1997
        public async Task<ActionResult> Index()
        {
            var model = await Task.Run(() =>
            {
                return Uow
                    .CategorySaleFor1997Repository
                    .GetAll()
                    .Select(item => new CategorySaleFor1997Model(item))
                    .ToList();
            });

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(FormCollection collection)
        {
            var model = await Task.Run(() =>
            {
                return Uow
                    .CategorySaleFor1997Repository
                    .GetAll()
                    .Select(item => new CategorySaleFor1997Model(item))
                    .ToList();
            });

            return View(model);
        }

        public async Task<ActionResult> Export(String id)
        {
            var model = await Task.Run(() =>
            {
                return Uow
                    .CategorySaleFor1997Repository
                    .GetAll()
                    .ToList();
            });

            var localReport = new LocalReport();
            var localReportPath = Path.Combine(Server.MapPath("~/Reports/"), "CategorySalesFor1997.rdlc");

            if (System.IO.File.Exists(localReportPath))
            {
                localReport.ReportPath = localReportPath;
            }
            else
            {
                return View("Index");
            }

            var mimeType = String.Empty;
            var fileNameExtension = String.Empty;

            var renderedBytes = localReport.Export("CategorySalesFor1997DataSet", model, id, out mimeType, out fileNameExtension);

            return File(renderedBytes, mimeType, String.Format("CategorySalesFor1997.{0}", fileNameExtension));
        }
    }
}
