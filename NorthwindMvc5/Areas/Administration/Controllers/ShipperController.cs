using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMvc5.Areas.Administration.Controllers
{
    public class ShipperController : Controller
    {
        public ShipperController()
        {

        }

        // GET: Administration/Shipper
        public ActionResult Index()
        {
            return View();
        }

        // GET: Administration/Shipper/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administration/Shipper/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Shipper/Create
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

        // GET: Administration/Shipper/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administration/Shipper/Edit/5
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

        // GET: Administration/Shipper/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administration/Shipper/Delete/5
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
