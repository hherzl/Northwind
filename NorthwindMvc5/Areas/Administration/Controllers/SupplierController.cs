using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMvc5.Areas.Administration.Controllers
{
    public class SupplierController : Controller
    {
        public SupplierController()
        {

        }

        // GET: Administration/Supplier
        public ActionResult Index()
        {
            return View();
        }

        // GET: Administration/Supplier/Details/5
        public ActionResult Details(int id)
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administration/Supplier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administration/Supplier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
