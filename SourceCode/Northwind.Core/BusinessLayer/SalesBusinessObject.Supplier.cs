using System.Collections.Generic;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer
{
    public partial class SalesBusinessObject : ISalesBusinessObject
    {
        public IEnumerable<Supplier> GetSuppliers()
        {
            return Uow.SupplierRepository.GetAll();
        }

        public Supplier GetSupplier(Supplier entity)
        {
            return Uow.SupplierRepository.Get(entity);
        }

        public Supplier CreateSupplier(Supplier entity)
        {
            Uow.SupplierRepository.Add(entity);

            Uow.CommitChanges();

            return entity;
        }

        public Supplier UpdateSupplier(Supplier value)
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

                Uow.CommitChanges();
            }

            return entity;
        }

        public Supplier DeleteSupplier(Supplier value)
        {
            var entity = Uow.SupplierRepository.Get(value);

            if (entity != null)
            {
                Uow.SupplierRepository.Remove(entity);

                Uow.CommitChanges();
            }

            return entity;
        }
    }
}
