using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Northwind.Core.DataLayer.Contracts;
using NorthwindMvc5.Areas.Reports.Models;
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
    }
}
