using System.Collections.Generic;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer
{
    public partial class SalesBusinessObject : ISalesBusinessObject
    {
        public IEnumerable<Region> GetRegions()
        {
            return Uow.RegionRepository.GetAll();
        }

        public Region GetRegion(Region entity)
        {
            return Uow.RegionRepository.Get(entity);
        }

        public Region CreateRegion(Region entity)
        {
            Uow.RegionRepository.Add(entity);

            Uow.CommitChanges();

            return entity;
        }

        public Region UpdateRegion(Region value)
        {
            var entity = Uow.RegionRepository.Get(value);

            if (entity != null)
            {
                entity.RegionDescription = value.RegionDescription;

                Uow.RegionRepository.Update(entity);

                Uow.CommitChanges();
            }

            return entity;
        }

        public Region DeleteRegion(Region value)
        {
            var entity = Uow.RegionRepository.Get(value);

            if (entity != null)
            {
                Uow.RegionRepository.Remove(entity);

                Uow.CommitChanges();
            }

            return entity;
        }
    }
}
