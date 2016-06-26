using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.DataLayer.Repositories;
using Northwind.Core.Helpers;

namespace Northwind.Core.DataLayer
{
    public abstract class Uow
    {
        protected Boolean Disposed;
        protected DbContext DbContext;

        public Uow(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        private IChangeLogRepository m_changeLogRepository;

        public IChangeLogRepository ChangeLogRepository
        {
            get
            {
                return m_changeLogRepository ?? (m_changeLogRepository = new ChangeLogRepository(DbContext));
            }
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }

            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public DbContextTransaction GetTransaction()
        {
            return DbContext.Database.BeginTransaction();
        }

        protected void AddChangesToLog()
        {
            foreach (var entry in DbContext.ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Modified)
                {
                    foreach (var change in EfExtensions.GetChanges(DbContext, entry))
                    {
                        ChangeLogRepository.Add(change);
                    }
                }
            }
        }

        public Int32 CommitChanges()
        {
            if (DbContext.ChangeTracker.HasChanges())
            {
                AddChangesToLog();

                return DbContext.SaveChanges();
            }

            return 0;
        }

        public Task<Int32> CommitChangesAsync()
        {
            if (DbContext.ChangeTracker.HasChanges())
            {
                AddChangesToLog();

                return DbContext.SaveChangesAsync();
            }
            else
            {
                return Task.Run(() => { return 0; });
            }
        }
    }
}
