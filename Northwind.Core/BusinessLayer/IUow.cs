using System;

namespace Northwind.Core.BusinessLayer
{
    public interface IUow : IDisposable
    {
        Int32 CommitChanges();
    }
}
