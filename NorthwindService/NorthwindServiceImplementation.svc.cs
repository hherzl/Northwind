using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Customer> GetCustomers()
        {
            return Uow.CustomerRepository.GetAll().ToList();
        }
    }
}
