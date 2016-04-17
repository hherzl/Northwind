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
    public class ShipperController : Controller
    {
        protected ISalesUow Uow;

        public ShipperController(IUowService service)
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

        // GET: Administration/Shipper
        public async Task<ActionResult> Index()
        {
            var model = await Task.Run(() =>
            {
                return Uow
                    .ShipperRepository
                    .GetAll()
                    .Select(item => new ShipperModel(item))
                    .ToList();
            });

            return View(model);
        }

        // GET: Administration/Shipper/Details/5
        public async Task<ActionResult> Details(Int32 id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.ShipperRepository.Get(new Shipper(id));
            });

            var model = new ShipperModel(entity);

            return View(model);
        }

        // GET: Administration/Shipper/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Shipper/Create
        [HttpPost]
        public async Task<ActionResult> Create(ShipperModel model)
        {
            try
            {
                var entity = new Shipper();

                entity.CompanyName = model.CompanyName;
                entity.Phone = model.Phone;

                Uow.ShipperRepository.Add(entity);

                await Uow.CommitChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Shipper/Edit/5
        public async Task<ActionResult> Edit(Int32 id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.ShipperRepository.Get(new Shipper(id));
            });

            var model = new ShipperModel(entity);

            return View(model);
        }

        // POST: Administration/Shipper/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Int32 id, ShipperModel model)
        {
            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.ShipperRepository.Get(new Shipper(id));
                });

                entity.CompanyName = model.CompanyName;
                entity.Phone = model.Phone;

                await Uow.CommitChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Shipper/Delete/5
        public async Task<ActionResult> Delete(Int32 id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.ShipperRepository.Get(new Shipper(id));
            });

            var model = new ShipperModel(entity);

            return View(model);
        }

        // POST: Administration/Shipper/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Int32 id, FormCollection collection)
        {
            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.ShipperRepository.Get(new Shipper(id));
                });

                Uow.ShipperRepository.Remove(entity);

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
