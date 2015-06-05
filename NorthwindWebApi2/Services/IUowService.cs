using Northwind.Core.DataLayer.OperationContracts;

namespace NorthwindWebApi2.Services
{
    public interface IUowService
    {
        ISalesUow GetSalesUow();
    }
}
