using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Northwind.Core.DataLayer.Contracts;
using NorthwindMvc5.Areas.Administration.Models;
using NorthwindMvc5.Services;
using EL = Northwind.Core.EntityLayer;

namespace NorthwindMvc5.Areas.Administration.Controllers
{
    public class RegionController : Controller
    {
        protected ISalesUow Uow;

        public RegionController(IUowService service)
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

        // GET: Administration/Region
        public async Task<ActionResult> Index()
        {
            var model = await Task.Run(() =>
            {
                return Uow
                    .RegionRepository
                    .GetAll()
                    .Select(item => new RegionModel(item))
                    .ToList();
            });

            return View(model);
        }

        // GET: Administration/Region/Details/5
        public async Task<ActionResult> Details(Int32 id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.RegionRepository.Get(new EL.Region(id));
            });

            var model = new RegionModel(entity);

            return View(model);
        }

        // GET: Administration/Region/Create
        public async Task<ActionResult> Create()
        {
            return await Task.Run(() =>
            {
                return View();
            });
        }

        // POST: Administration/Region/Create
        [HttpPost]
        public async Task<ActionResult> Create(RegionModel model)
        {
            try
            {
                var entity = new EL.Region();

                entity.RegionID = model.RegionID;
                entity.RegionDescription = model.RegionDescription.Trim();

                Uow.RegionRepository.Add(entity);

                await Uow.CommitChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Region/Edit/5
        public async Task<ActionResult> Edit(Int32 id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.RegionRepository.Get(new EL.Region(id));
            });

            var model = new RegionModel(entity);

            return View(model);
        }

        // POST: Administration/Region/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Int32 id, RegionModel model)
        {
            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.RegionRepository.Get(new EL.Region(id));
                });

                entity.RegionDescription = model.RegionDescription;

                await Uow.CommitChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Region/Delete/5
        public async Task<ActionResult> Delete(Int32 id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.RegionRepository.Get(new EL.Region(id));
            });

            var model = new RegionModel(entity);

            return View(model);
        }

        // POST: Administration/Region/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Int32 id, FormCollection collection)
        {
            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.RegionRepository.Get(new EL.Region(id));
                });

                Uow.RegionRepository.Remove(entity);

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
