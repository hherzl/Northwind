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
        public async Task<ActionResult> Index()
        {
            var model = await Task.Run(() =>
            {
                return Uow
                    .SupplierRepository
                    .GetAll()
                    .Select(item => new SupplierModel(item))
                    .ToList();
            });

            return View(model);
        }

        // GET: Administration/Supplier/Details/5
        public async Task<ActionResult> Details(Int32 id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.SupplierRepository.Get(new Supplier(id));
            });

            var model = new SupplierModel(entity);

            return View(model);
        }

        // GET: Administration/Supplier/Create
        public async Task<ActionResult> Create()
        {
            return await Task.Run(() =>
            {
                return View();
            });
        }

        // POST: Administration/Supplier/Create
        [HttpPost]
        public async Task<ActionResult> Create(SupplierModel model)
        {
            try
            {
                var entity = new Supplier();

                Uow.SupplierRepository.Add(entity);

                await Uow.CommitChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Supplier/Edit/5
        public async Task<ActionResult> Edit(Int32 id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.SupplierRepository.Get(new Supplier(id));
            });

            var model = new SupplierModel(entity);

            return View(model);
        }

        // POST: Administration/Supplier/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Int32 id, SupplierModel model)
        {
            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.SupplierRepository.Get(new Supplier(id));
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
                entity.HomePage = model.HomePage;

                await Uow.CommitChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Supplier/Delete/5
        public async Task<ActionResult> Delete(Int32 id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.SupplierRepository.Get(new Supplier(id));
            });

            var model = new SupplierModel(entity);

            return View(model);
        }

        // POST: Administration/Supplier/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Int32 id, SupplierModel model)
        {
            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.SupplierRepository.Get(new Supplier(id));
                });

                Uow.SupplierRepository.Remove(entity);

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
