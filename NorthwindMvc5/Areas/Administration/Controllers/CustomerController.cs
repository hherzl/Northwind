using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;
using NorthwindMvc5.Areas.Administration.Models;
using NorthwindMvc5.Services;

namespace NorthwindMvc5.Areas.Administration.Controllers
{
    public class CustomerController : Controller
    {
        protected ISalesUow Uow;

        public CustomerController(IUowService service)
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

        // GET: Administration/Customer
        public async Task<ActionResult> Index()
        {
            var model = await Task.Run(() =>
            {
                return Uow.CustomerRepository.GetAll().ToList();
            });

            return View(model);
        }

        // GET: Administration/Customer/Details/5
        public async Task<ActionResult> Details(String id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.CustomerRepository.Get(new Customer() { CustomerID = id });
            });

            var model = new CustomerModel(entity);

            return View(model);
        }

        // GET: Administration/Customer/Create
        public async Task<ActionResult> Create()
        {
            return await Task.Run(() =>
            {
                return View();
            });
        }

        // POST: Administration/Customer/Create
        [HttpPost]
        public async Task<ActionResult> Create(CustomerModel model)
        {
            try
            {
                var entity = new Customer();

                Uow.CustomerRepository.Add(entity);

                await Uow.CommitChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Customer/Edit/5
        public async Task<ActionResult> Edit(String id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.CustomerRepository.Get(new Customer() { CustomerID = id });
            });

            var model = new CustomerModel(entity);

            return View(model);
        }

        // POST: Administration/Customer/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(String id, CustomerModel model)
        {
            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.CustomerRepository.Get(new Customer() { CustomerID = id });
                });

                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Customer/Delete/5
        public async Task<ActionResult> Delete(String id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.CustomerRepository.Get(new Customer() { CustomerID = id });
            });

            var model = new CustomerModel(entity);

            return View(model);
        }

        // POST: Administration/Customer/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(String id, CustomerModel model)
        {
            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.CustomerRepository.Get(new Customer() { CustomerID = id });
                });

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
