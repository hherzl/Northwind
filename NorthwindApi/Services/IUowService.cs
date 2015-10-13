using Northwind.Core.DataLayer.Contracts;

namespace NorthwindApi.Services
{
    public interface IUowService
    {
        ISalesUow GetSalesUow();
    }
}
