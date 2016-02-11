using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer
{
    public partial class SalesBusinessObject : ISalesBusinessObject
    {
        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await Task.Run(() =>
            {
                return Uow
                    .SupplierRepository
                    .GetAll();
            });
        }

        public async Task<Supplier> GetSupplier(Supplier entity)
        {
            return await Task.Run(() =>
            {
                return Uow
                    .SupplierRepository
                    .Get(entity);
            });
        }

        public async Task<Supplier> CreateSupplier(Supplier entity)
        {
            Uow.SupplierRepository.Add(entity);

            await Uow.CommitChangesAsync();

            return entity;
        }

        public async Task<Supplier> UpdateSupplier(Supplier value)
        {
            var entity = Uow.SupplierRepository.Get(value);

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
                entity.HomePage = value.HomePage;

                Uow.SupplierRepository.Update(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }

        public async Task<Supplier> DeleteSupplier(Supplier value)
        {
            var entity = Uow.SupplierRepository.Get(value);

            if (entity != null)
            {
                Uow.SupplierRepository.Remove(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }
    }
}
