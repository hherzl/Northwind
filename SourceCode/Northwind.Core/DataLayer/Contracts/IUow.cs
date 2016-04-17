using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Northwind.Core.DataLayer.Contracts
{
    public interface IUow : IDisposable
    {
        DbContextTransaction GetTransaction();

        Int32 CommitChanges();

        Task<Int32> CommitChangesAsync();
    }
}
