using System;
using System.Data.Entity;
using System.Linq;

namespace Northwind.Core.DataLayer
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext DbContext;
        protected DbSet<TEntity> DbSet;

        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;

            DbSet = DbContext.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual TEntity Get(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Add(TEntity entity)
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

        public virtual void Update(TEntity entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }
    }
}
