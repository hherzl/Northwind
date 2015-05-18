using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMvc5.Areas.Administration.Controllers
{
    public class ProductController : Controller
    {
        public ProductController()
        {

        }

        // GET: Administration/Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Administration/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administration/Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Product/Create
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

        // GET: Administration/Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administration/Product/Edit/5
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

        // GET: Administration/Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administration/Product/Delete/5
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
