using System;
using System.Threading.Tasks;

namespace Northwind.Core.DataLayer.Contracts
{
    public interface IUow : IDisposable
    {
        Int32 CommitChanges();

        Task<Int32> CommitChangesAsync();
    }
}
