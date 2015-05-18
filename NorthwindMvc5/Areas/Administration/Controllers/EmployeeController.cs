using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMvc5.Areas.Administration.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeController()
        {

        }

        // GET: Administration/Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: Administration/Employee/Details/5
        public ActionResult Details(int id)
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administration/Employee/Edit/5
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

        // GET: Administration/Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administration/Employee/Delete/5
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
