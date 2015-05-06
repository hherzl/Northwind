using Northwind.Core.BusinessLayer;

namespace NorthwindWebApi2.Services
{
    public interface IUowService
    {
        ISalesUow GetSalesUow();
    }
}
