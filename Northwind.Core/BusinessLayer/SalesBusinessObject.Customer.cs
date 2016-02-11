using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer
{
    public partial class SalesBusinessObject : ISalesBusinessObject
    {
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await Task.Run(() =>
            {
                return Uow
                    .CustomerRepository
                    .GetAll();
            });
        }

        public async Task<Customer> GetCustomer(Customer entity)
        {
            return await Task.Run(() =>
            {
                return Uow
                    .CustomerRepository
                    .Get(entity);
            });
        }

        public async Task<Customer> CreateCustomer(Customer entity)
        {
            Uow.CustomerRepository.Add(entity);

            await Uow.CommitChangesAsync();

            return entity;
        }

        public async Task<Customer> UpdateCustomer(Customer value)
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

                await Uow.CommitChangesAsync();
            }

            return entity;
        }

        public async Task<Customer> DeleteCustomer(Customer value)
        {
            var entity = Uow.CustomerRepository.Get(value);

            if (entity != null)
            {
                Uow.CustomerRepository.Remove(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }
    }
}
