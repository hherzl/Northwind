using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer
{
    public partial class SalesBusinessObject : ISalesBusinessObject
    {
        public async Task<IEnumerable<Region>> GetRegions()
        {
            return await Task.Run(() =>
            {
                return Uow
                    .RegionRepository
                    .GetAll();
            });
        }

        public async Task<Region> GetRegion(Region entity)
        {
            return await Task.Run(() =>
            {
                return Uow
                    .RegionRepository
                    .Get(entity);
            });
        }

        public async Task<Region> CreateRegion(Region entity)
        {
            Uow.RegionRepository.Add(entity);

            await Uow.CommitChangesAsync();

            return entity;
        }

        public async Task<Region> UpdateRegion(Region value)
        {
            var entity = Uow.RegionRepository.Get(value);

            if (entity != null)
            {
                entity.RegionDescription = value.RegionDescription;

                Uow.RegionRepository.Update(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }

        public async Task<Region> DeleteRegion(Region value)
        {
            var entity = Uow.RegionRepository.Get(value);

            if (entity != null)
            {
                Uow.RegionRepository.Remove(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }
    }
}
