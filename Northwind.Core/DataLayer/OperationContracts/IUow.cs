using System;

namespace Northwind.Core.DataLayer.OperationContracts
{
    public interface IUow : IDisposable
    {
        Int32 CommitChanges();
    }
}
