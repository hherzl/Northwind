using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer
{
    public partial class SalesBusinessObject : ISalesBusinessObject
    {
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await Task.Run(() =>
            {
                return Uow
                    .EmployeeRepository
                    .GetAll();
            });
        }

        public async Task<Employee> GetEmployee(Employee entity)
        {
            return await Task.Run(() =>
            {
                return Uow
                    .EmployeeRepository
                    .Get(entity);
            });
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await Task.Run(() =>
            {
                return Uow
                    .CategoryRepository
                    .GetAll();
            });
        }

        public async Task<Category> GetCategory(Category entity)
        {
            return await Task.Run(() =>
            {
                return Uow
                    .CategoryRepository
                    .Get(entity);
            });
        }
    }
}
