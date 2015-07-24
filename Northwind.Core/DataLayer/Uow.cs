using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Northwind.Core.DataLayer
{
    public abstract class Uow
    {
        protected Boolean Disposed;
        protected DbContext DatabaseContext;

        public Uow(DbContext dbContext)
        {
            DatabaseContext = dbContext;
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    DatabaseContext.Dispose();
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
            if (DatabaseContext.ChangeTracker.HasChanges())
            {
                return DatabaseContext.SaveChanges();
            }

            return 0;
        }

        public Task<Int32> CommitChangesAsync()
        {
            if (DatabaseContext.ChangeTracker.HasChanges())
            {
                return DatabaseContext.SaveChangesAsync();
            }
            else
            {
                return Task.Run(() => { return 0; });
            }
        }
    }
}
