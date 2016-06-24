using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer
{
    public partial class SalesBusinessObject : ISalesBusinessObject
    {
        public Category CreateCategory(Category entity)
        {
            Uow.CategoryRepository.Add(entity);

            Uow.CommitChanges();

            return entity;
        }

        public Category UpdateCategory(Category value)
        {
            var entity = Uow.CategoryRepository.Get(value);

            if (entity != null)
            {
                entity.CategoryName = value.CategoryName;
                entity.Description = value.Description;
                entity.Picture = value.Picture;

                Uow.CategoryRepository.Update(entity);

                Uow.CommitChanges();
            }

            return entity;
        }

        public Category DeleteCategory(Category value)
        {
            var entity = Uow.CategoryRepository.Get(value);

            if (entity != null)
            {
                Uow.CategoryRepository.Remove(entity);

                Uow.CommitChanges();
            }

            return entity;
        }
    }
}
