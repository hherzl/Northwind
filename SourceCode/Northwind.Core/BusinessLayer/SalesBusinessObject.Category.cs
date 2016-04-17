using System.Threading.Tasks;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer
{
    public partial class SalesBusinessObject : ISalesBusinessObject
    {
        public async Task<Category> CreateCategory(Category entity)
        {
            Uow.CategoryRepository.Add(entity);

            await Uow.CommitChangesAsync();

            return entity;
        }

        public async Task<Category> UpdateCategory(Category value)
        {
            var entity = Uow.CategoryRepository.Get(value);

            if (entity != null)
            {
                entity.CategoryName = value.CategoryName;
                entity.Description = value.Description;
                entity.Picture = value.Picture;

                Uow.CategoryRepository.Update(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }

        public async Task<Category> DeleteCategory(Category value)
        {
            var entity = Uow.CategoryRepository.Get(value);

            if (entity != null)
            {
                Uow.CategoryRepository.Remove(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }
    }
}
