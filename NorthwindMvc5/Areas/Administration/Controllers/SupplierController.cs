using System;
using System.Web.Mvc;
using Northwind.Core.DataLayer.Contracts;
using NorthwindMvc5.Services;

namespace NorthwindMvc5.Areas.Administration.Controllers
{
    public class SupplierController : Controller
    {
        protected ISalesUow Uow;

        public SupplierController(IUowService service)
        {
            Uow = service.GetSalesUow();
        }

        protected override void Dispose(Boolean disposing)
        {
            if (Uow != null)
            {
                Uow.Dispose();
            }

            base.Dispose(disposing);
        }

        // GET: Administration/Supplier
        public ActionResult Index()
        {
            return View();
        }

        // GET: Administration/Supplier/Details/5
        public ActionResult Details(Int32 id)
        {
            return View();
        }

        // GET: Administration/Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Supplier/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Supplier/Edit/5
        public ActionResult Edit(Int32 id)
        {
            return View();
        }

        // POST: Administration/Supplier/Edit/5
        [HttpPost]
        public ActionResult Edit(Int32 id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Supplier/Delete/5
        public ActionResult Delete(Int32 id)
        {
            return View();
        }

        // POST: Administration/Supplier/Delete/5
        [HttpPost]
        public ActionResult Delete(Int32 id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
