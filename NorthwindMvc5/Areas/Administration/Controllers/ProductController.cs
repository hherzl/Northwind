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
    public class ProductController : Controller
    {
        protected ISalesUow Uow;

        public ProductController(IUowService service)
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

        // GET: Administration/Product
        public async Task<ActionResult> Index()
        {
            var model = await Task.Run(() =>
            {
                return Uow.ProductRepository.GetDetails(String.Empty, null, null).ToList();
            });

            return View(model);
        }

        // GET: Administration/Product/Details/5
        public async Task<ActionResult> Details(Int32 id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.ProductRepository.Get(new Product() { ProductID = id });
            });

            var model = new ProductModel(entity);

            return View(model);
        }

        // GET: Administration/Product/Create
        public async Task<ActionResult> Create()
        {
            return await Task.Run(() =>
            {
                return View();
            });
        }

        // POST: Administration/Product/Create
        [HttpPost]
        public async Task<ActionResult> Create(ProductModel model)
        {
            try
            {
                var entity = new Product();

                Uow.ProductRepository.Add(entity);

                await Uow.CommitChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Product/Edit/5
        public async Task<ActionResult> Edit(Int32 id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.ProductRepository.Get(new Product() { ProductID = id });
            });

            var model = new ProductModel(entity);

            return View(model);
        }

        // POST: Administration/Product/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Int32 id, ProductModel model)
        {
            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.ProductRepository.Get(new Product() { ProductID = id });
                });

                await Uow.CommitChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Product/Delete/5
        public async Task<ActionResult> Delete(Int32 id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.ProductRepository.Get(new Product() { ProductID = id });
            });

            var model = new ProductModel(entity);

            return View(model);
        }

        // POST: Administration/Product/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Int32 id, ProductModel model)
        {
            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.ProductRepository.Get(new Product() { ProductID = id });
                });

                Uow.ProductRepository.Remove(entity);

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
