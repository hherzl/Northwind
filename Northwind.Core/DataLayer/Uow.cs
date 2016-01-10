using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.Helpers;

namespace Northwind.Core.DataLayer
{
    public abstract class Uow
    {
        private IChangeLogRepository m_changeLogRepository;
        protected Boolean Disposed;
        protected DbContext Context;

        public Uow(DbContext dbContext)
        {
            Context = dbContext;
        }

        public IChangeLogRepository ChangeLogRepository
        {
            get
            {
                return m_changeLogRepository ?? (m_changeLogRepository = new ChangeLogRepository(Context));
            }
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }

            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public Int32 CommitChanges()
        {
            if (Context.ChangeTracker.HasChanges())
            {
                foreach (var entry in Context.ChangeTracker.Entries())
                {
                    if (entry.State == EntityState.Modified)
                    {
                        foreach (var change in ChangeTrackerHelper.GetChanges(Context, entry))
                        {
                            ChangeLogRepository.Add(change);
                        }
                    }
                }

                return Context.SaveChanges();
            }

            return 0;
        }

        public Task<Int32> CommitChangesAsync()
        {
            if (Context.ChangeTracker.HasChanges())
            {
                foreach (var entry in Context.ChangeTracker.Entries())
                {
                    if (entry.State == EntityState.Modified)
                    {
                        foreach (var change in ChangeTrackerHelper.GetChanges(Context, entry))
                        {
                            ChangeLogRepository.Add(change);
                        }
                    }
                }

                return Context.SaveChangesAsync();
            }
            else
            {
                return Task.Run(() => { return 0; });
            }
        }
    }
}
