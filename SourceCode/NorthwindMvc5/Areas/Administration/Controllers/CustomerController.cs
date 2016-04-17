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
                return Uow
                    .CustomerRepository
                    .GetAll()
                    .ToList();
            });

            return View(model);
        }

        // GET: Administration/Customer/Details/5
        public async Task<ActionResult> Details(String id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.CustomerRepository.Get(new Customer(id));
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
                return Uow.CustomerRepository.Get(new Customer(id));
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
                    return Uow.CustomerRepository.Get(new Customer(id));
                });

                entity.CompanyName = model.CompanyName;
                entity.ContactName = model.ContactName;
                entity.ContactTitle = model.ContactTitle;
                entity.Address = model.Address;
                entity.City = model.City;
                entity.Region = model.Region;
                entity.PostalCode = model.PostalCode;
                entity.Country = model.Country;
                entity.Phone = model.Phone;
                entity.Fax = model.Fax;

                await Uow.CommitChangesAsync();

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
                return Uow.CustomerRepository.Get(new Customer(id));
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
                    return Uow.CustomerRepository.Get(new Customer(id));
                });

                Uow.CustomerRepository.Remove(entity);

                await Uow.CommitChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
