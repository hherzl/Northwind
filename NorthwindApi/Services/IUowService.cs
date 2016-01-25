using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.DataLayer.Contracts;

namespace NorthwindApi.Services
{
    public interface IUowService
    {
        ISalesUow GetSalesUow();

        ISalesBusinessObject GetSalesBusinessObject();
    }
}
