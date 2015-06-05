using System.Linq;

namespace Northwind.Core.DataLayer
{
    public interface IRepository<E> where E : class
    {
        IQueryable<E> GetAll();

        E Get(E entity);

        void Add(E entity);

        void Update(E entity);

        void Remove(E entity);
    }
}
