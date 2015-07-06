using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Core.DataLayer
{
    public abstract class Repository<E> : IRepository<E> where E : class
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

        public virtual Task<E> GetAsync(E entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Add(E entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual void Update(E entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Remove(E entity)
        {
            DbSet.Remove(entity);
        }
    }
}
