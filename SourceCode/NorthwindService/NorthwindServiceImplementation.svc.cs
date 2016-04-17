using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Northwind.Core.DataLayer;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace NorthwindService
{
    public class NorthwindServiceImplementation : INorthwindService
    {
        protected ISalesUow Uow;

        public NorthwindServiceImplementation()
        {
            Uow = new SalesUow(new SalesDbContext());
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await Task.Run(() =>
            {
                return Uow.CustomerRepository.GetAll().ToList();
            });
        }

        public async Task AddCustomer(Customer entity)
        {
            Uow.CustomerRepository.Add(entity);

            await Uow.CommitChangesAsync();
        }

        public async Task<Customer> GetCustomer(String customerID)
        {
            return await Task.Run(() =>
            {
                return Uow.CustomerRepository.Get(new Customer { CustomerID = customerID });
            });
        }
    }
}
