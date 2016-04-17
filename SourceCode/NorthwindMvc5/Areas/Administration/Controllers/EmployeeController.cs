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
    public class EmployeeController : Controller
    {
        protected ISalesUow Uow;

        public EmployeeController(IUowService service)
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

        // GET: Administration/Employee
        public async Task<ActionResult> Index()
        {
            var model = await Task.Run(() =>
            {
                return Uow.EmployeeRepository.GetAll().ToList();
            });

            return View(model);
        }

        // GET: Administration/Employee/Details/5
        public async Task<ActionResult> Details(Int32 id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.EmployeeRepository.Get(new Employee() { EmployeeID = id });
            });

            var model = new EmployeeModel(entity);

            return View(model);
        }

        // GET: Administration/Employee/Create
        public async Task<ActionResult> Create()
        {
            return await Task.Run(() =>
            {
                return View();
            });
        }

        // POST: Administration/Employee/Create
        [HttpPost]
        public async Task<ActionResult> Create(EmployeeModel model)
        {
            try
            {
                var entity = new Employee();

                Uow.EmployeeRepository.Add(entity);

                await Uow.CommitChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Employee/Edit/5
        public async Task<ActionResult> Edit(Int32 id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.EmployeeRepository.Get(new Employee() { EmployeeID = id });
            });

            var model = new EmployeeModel(entity);

            return View(model);
        }

        // POST: Administration/Employee/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Int32 id, EmployeeModel model)
        {
            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.EmployeeRepository.Get(new Employee() { EmployeeID = id });
                });

                await Uow.CommitChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Employee/Delete/5
        public async Task<ActionResult> Delete(Int32 id)
        {
            var entity = await Task.Run(() =>
            {
                return Uow.EmployeeRepository.Get(new Employee() { EmployeeID = id });
            });

            var model = new EmployeeModel(entity);

            return View(model);
        }

        // POST: Administration/Employee/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Int32 id, EmployeeModel model)
        {
            try
            {
                var entity = await Task.Run(() =>
                {
                    return Uow.EmployeeRepository.Get(new Employee() { EmployeeID = id });
                });

                Uow.EmployeeRepository.Remove(entity);

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
