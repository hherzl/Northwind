using System;
using System.Data.Entity;
using System.Linq;

namespace Northwind.Core.DataLayer
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext DbCtx;
        protected DbSet<TEntity> DbSet;

        public Repository(DbContext dbContext)
        {
            DbCtx = dbContext;

            DbSet = DbCtx.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual TEntity Get(TEntity entity)
        {
            throw new NotImplementedException(String.Format("There is not implementation for 'Get' operation in '{0}' repostory", typeof(IRepository<TEntity>).FullName));
        }

        public virtual void Add(TEntity entity)
        {
            var dbEntityEntry = DbCtx.Entry(entity);

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
            var dbEntityEntry = DbCtx.Entry(entity);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Remove(TEntity entity)
        {
            var dbEntityEntry = DbCtx.Entry(entity);

            if (dbEntityEntry.State == EntityState.Deleted)
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
            else
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
        }
    }
}
