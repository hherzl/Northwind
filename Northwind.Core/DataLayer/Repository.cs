using System;
using System.Data.Entity;
using System.Linq;
using Northwind.Core.Practices;

namespace Northwind.Core.DataLayer
{
    public class Repository<E> : IRepository<E> where E : class
    {
        protected DbContext DbContext;
        protected DbSet<E> DbSet;

        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;

            DbSet = DbContext.Set<E>();
        }

        public virtual IQueryable<E> GetAll()
        {
            return DbSet;
        }

        public virtual E Get(E entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Add(E entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(E entity)
        {

        }

        public virtual void Remove(E entity)
        {
            DbSet.Remove(entity);
        }
    }
}
