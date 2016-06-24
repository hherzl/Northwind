using System.Collections.Generic;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer
{
    public partial class SalesBusinessObject : ISalesBusinessObject
    {
        public IEnumerable<Employee> GetEmployees()
        {
            return Uow.EmployeeRepository.GetAll();
        }

        public Employee GetEmployee(Employee entity)
        {
            return Uow.EmployeeRepository.Get(entity);
        }

        public IEnumerable<Category> GetCategories()
        {
            return Uow.CategoryRepository.GetAll();
        }

        public Category GetCategory(Category entity)
        {
            return Uow.CategoryRepository.Get(entity);
        }
    }
}
