using System;
using System.Linq;
using System.Web.Mvc;
using Northwind.Core.DataLayer.OperationContracts;
using Northwind.Core.EntityLayer;
using NorthwindMvc5.Services;
using PagedList;

namespace NorthwindMvc5.Areas.Administration.Controllers
{
    public class OrderController : Controller
    {
        protected ISalesUow Uow;

        public OrderController(IUowService service)
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

        public OrderController()
        {

        }

        // GET: Administration/Order
        public ActionResult Index(Int32? pageNumber, Int32? pageSize, String sortName, String orderID, String customer, String employee, String shipper)
        {
            ViewBag.PageNumber = pageNumber ?? 1;
            ViewBag.PageSize = pageSize ?? 10;
            ViewBag.SortName = sortName;
            ViewBag.OrderID = orderID;
            ViewBag.Customer = customer;
            ViewBag.Employee = employee;
            ViewBag.Shipper = shipper;

            ViewBag.OrderSortName = sortName == "Order" ? "Order_desc" : "Order";

            var query = Uow.OrderRepository.GetSummaries();

            if (!String.IsNullOrEmpty(orderID))
            {
                query = query.Where(item => item.OrderID.ToString().Contains(orderID));
            }

            if (!String.IsNullOrEmpty(customer))
            {
                query = query.Where(item => item.Customer.Contains(customer));
            }

            if (!String.IsNullOrEmpty(employee))
            {
                query = query.Where(item => item.Employee.Contains(employee));
            }

            if (!String.IsNullOrEmpty(shipper))
            {
                query = query.Where(item => item.Shipper.Contains(shipper));
            }

            switch (sortName)
            {
                case "Order_desc":
                    query = query.OrderByDescending(item => item.OrderID);
                    break;

                default:
                    query = query.OrderBy(item => item.OrderID);
                    break;
            }

            return View(query.ToPagedList((Int32)ViewBag.PageNumber, (Int32)ViewBag.PageSize));
        }

        // GET: Administration/Order/Details/5
        public ActionResult Details(Int32 id)
        {
            var model = Uow.OrderRepository.Get(new Order() { OrderID = id });

            return View(model);
        }

        // GET: Administration/Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Order/Create
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

        // GET: Administration/Order/Edit/5
        public ActionResult Edit(Int32 id)
        {
            return View();
        }

        // POST: Administration/Order/Edit/5
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

        // GET: Administration/Order/Delete/5
        public ActionResult Delete(Int32 id)
        {
            return View();
        }

        // POST: Administration/Order/Delete/5
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
