using Northwind.Core.DataLayer.Contracts;

namespace NorthwindWebApi2.Services
{
    public interface IUowService
    {
        ISalesUow GetSalesUow();
    }
}
