using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Northwind.Core.DataLayer
{
    public abstract class Uow
    {
        protected Boolean Disposed;
        protected DbContext DbCtx;

        public Uow(DbContext dbContext)
        {
            DbCtx = dbContext;
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    DbCtx.Dispose();
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
            if (DbCtx.ChangeTracker.HasChanges())
            {
                return DbCtx.SaveChanges();
            }

            return 0;
        }

        public Task<Int32> CommitChangesAsync()
        {
            if (DbCtx.ChangeTracker.HasChanges())
            {
                return DbCtx.SaveChangesAsync();
            }
            else
            {
                return Task.Run(() => { return 0; });
            }
        }
    }
}
