using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.DataLayer
{
    public abstract class Uow
    {
        protected Boolean m_disposed;
        protected DbContext m_dbContext;

        public Uow(DbContext dbContext)
        {
            m_dbContext = dbContext;
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_dbContext.Dispose();
                }
            }

            m_disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public Int32 CommitChanges()
        {
            if (m_dbContext.ChangeTracker.HasChanges())
            {
                return m_dbContext.SaveChanges();
            }

            return 0;
        }

        public Task<Int32> CommitChangesAsync()
        {
            return m_dbContext.SaveChangesAsync();
        }
    }
}
