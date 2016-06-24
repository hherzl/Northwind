using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer
{
    public partial class SalesBusinessObject : ISalesBusinessObject
    {
        public IEnumerable<Customer> GetCustomers()
        {
            return Uow.CustomerRepository.GetAll();
        }

        public Customer GetCustomer(Customer entity)
        {
            return Uow.CustomerRepository.Get(entity);
        }

        public Customer CreateCustomer(Customer entity)
        {
            if (entity != null && !String.IsNullOrEmpty(entity.CustomerID))
            {
                entity.CustomerID = entity.CompanyName.Substring(0, 5).ToUpper();
            }

            Uow.CustomerRepository.Add(entity);

            Uow.CommitChanges();

            return entity;
        }

        public Customer UpdateCustomer(Customer value)
        {
            var entity = Uow.CustomerRepository.Get(value);

            if (entity != null)
            {
                entity.CompanyName = value.CompanyName;
                entity.ContactName = value.ContactName;
                entity.ContactTitle = value.ContactTitle;
                entity.Address = value.Address;
                entity.City = value.City;
                entity.Region = value.Region;
                entity.PostalCode = value.PostalCode;
                entity.Country = value.Country;
                entity.Phone = value.Phone;
                entity.Fax = value.Fax;

                Uow.CustomerRepository.Update(entity);

                Uow.CommitChanges();
            }

            return entity;
        }

        public Customer DeleteCustomer(Customer value)
        {
            var entity = Uow.CustomerRepository.Get(value);

            if (entity != null)
            {
                Uow.CustomerRepository.Remove(entity);

                Uow.CommitChanges();
            }

            return entity;
        }
    }
}
