using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer
{
    public partial class SalesBusinessObject : ISalesBusinessObject
    {
        public async Task<IEnumerable<Shipper>> GetShippers()
        {
            return await Task.Run(() =>
            {
                return Uow
                    .ShipperRepository
                    .GetAll();
            });
        }

        public async Task<Shipper> GetShipper(Shipper entity)
        {
            return await Task.Run(() =>
            {
                return Uow
                    .ShipperRepository
                    .Get(entity);
            });
        }

        public async Task<Shipper> CreateShipper(Shipper entity)
        {
            Uow.ShipperRepository.Add(entity);

            await Uow.CommitChangesAsync();

            return entity;
        }

        public async Task<Shipper> UpdateShipper(Shipper value)
        {
            var entity = Uow.ShipperRepository.Get(value);

            if (entity != null)
            {
                entity.CompanyName = value.CompanyName;
                entity.Phone = value.Phone;

                Uow.ShipperRepository.Update(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }

        public async Task<Shipper> DeleteShipper(Shipper value)
        {
            var entity = Uow.ShipperRepository.Get(value);

            if (entity != null)
            {
                var task = await GetOrdersByShipVia(entity.ShipperID);

                if (task.Count() > 0)
                {
                    throw new ForeignKeyDependencyException(String.Format("Unable to delete shipper with id: '{0}', because has orders associated.", entity.ShipperID));
                }

                Uow.ShipperRepository.Remove(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }
    }
}
