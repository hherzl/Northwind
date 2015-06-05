using System;
using System.Web.Mvc;
using Northwind.Core.DataLayer.OperationContracts;
using NorthwindMvc5.Services;

namespace NorthwindMvc5.Areas.Administration.Controllers
{
    public class EmployeeController : Controller
    {
        protected ISalesUow Uow;

        public EmployeeController(IUowService service)
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

        // GET: Administration/Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: Administration/Employee/Details/5
        public ActionResult Details(Int32 id)
        {
            return View();
        }

        // GET: Administration/Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Employee/Create
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

        // GET: Administration/Employee/Edit/5
        public ActionResult Edit(Int32 id)
        {
            return View();
        }

        // POST: Administration/Employee/Edit/5
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

        // GET: Administration/Employee/Delete/5
        public ActionResult Delete(Int32 id)
        {
            return View();
        }

        // POST: Administration/Employee/Delete/5
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
