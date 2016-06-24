using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer
{
    public partial class SalesBusinessObject : ISalesBusinessObject
    {
        public IEnumerable<Shipper> GetShippers()
        {
            return Uow.ShipperRepository.GetAll();
        }

        public Shipper GetShipper(Shipper entity)
        {
            return Uow.ShipperRepository.Get(entity);
        }

        public Shipper CreateShipper(Shipper entity)
        {
            Uow.ShipperRepository.Add(entity);

            Uow.CommitChanges();

            return entity;
        }

        public Shipper UpdateShipper(Shipper value)
        {
            var entity = Uow.ShipperRepository.Get(value);

            if (entity != null)
            {
                entity.CompanyName = value.CompanyName;
                entity.Phone = value.Phone;

                Uow.ShipperRepository.Update(entity);

                Uow.CommitChanges();
            }

            return entity;
        }

        public Shipper DeleteShipper(Shipper value)
        {
            var entity = Uow.ShipperRepository.Get(value);

            if (entity != null)
            {
                var relatedOrders = GetOrdersByShipVia(entity.ShipperID);

                if (relatedOrders.Count() > 0)
                {
                    throw new ForeignKeyDependencyException(String.Format("Unable to delete shipper with id: '{0}', because has orders associated.", entity.ShipperID));
                }

                Uow.ShipperRepository.Remove(entity);

                Uow.CommitChanges();
            }

            return entity;
        }
    }
}
