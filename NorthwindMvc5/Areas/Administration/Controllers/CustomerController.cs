using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMvc5.Areas.Administration.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerController()
        {

        }

        // GET: Administration/Customer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Administration/Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administration/Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Customer/Create
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

        // GET: Administration/Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administration/Customer/Edit/5
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

        // GET: Administration/Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administration/Customer/Delete/5
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
