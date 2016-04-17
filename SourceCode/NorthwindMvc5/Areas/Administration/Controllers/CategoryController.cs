using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;
using NorthwindMvc5.Areas.Administration.Models;
using NorthwindMvc5.Services;

namespace NorthwindMvc5.Areas.Administration.Controllers
{
    public class CategoryController : BaseController
    {
        protected ISalesUow Uow;

        public CategoryController(IUowService service)
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

        // GET: Administration/Category
        public async Task<ActionResult> Index()
        {
            var model = await Task.Run(() =>
            {
                return Uow
                    .CategoryRepository
                    .GetAll()
                    .Select(item => new CategoryModel()
                    {
                        CategoryID = item.CategoryID,
                        CategoryName = item.CategoryName,
                        Description = item.Description
                    })
                    .ToList();
            });

            return View(model);
        }

        // GET: Administration/Category/Details/5
        public async Task<ActionResult> Details(Int32 id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.CategoryRepository.Get(new Category(id));
            });

            var model = new CategoryModel(entity);

            return View(model);
        }

        // GET: Administration/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Category/Create
        [HttpPost]
        public async Task<ActionResult> Create(CategoryModel model)
        {
            try
            {
                var entity = new Category();

                entity.CategoryName = model.CategoryName;
                entity.Description = model.Description;

                Uow.CategoryRepository.Add(entity);

                await Uow.CommitChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Category/Edit/5
        public async Task<ActionResult> Edit(Int32 id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.CategoryRepository.Get(new Category(id));
            });

            var model = new CategoryModel(entity);

            return View(model);
        }

        // POST: Administration/Category/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Int32 id, CategoryModel model)
        {
            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.CategoryRepository.Get(new Category(id));
                });

                entity.CategoryName = model.CategoryName;
                entity.Description = model.Description;

                await Uow.CommitChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Category/Delete/5
        public async Task<ActionResult> Delete(Int32 id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.CategoryRepository.Get(new Category(id));
            });

            var model = new CategoryModel(entity);

            return View(model);
        }

        // POST: Administration/Category/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Int32 id, CategoryModel model)
        {
            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.CategoryRepository.Get(new Category(id));
                });

                Uow.CategoryRepository.Remove(entity);

                await Uow.CommitChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Administration/Category/Upload/5
        [HttpPost]
        public ActionResult Upload(Int32 id, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                upload.SaveAs(Server.MapPath(String.Format("~/Uploads/{0}", Path.GetFileName(upload.FileName))));
            }

            return RedirectToAction("Details", new { id = id });
        }
    }
}
