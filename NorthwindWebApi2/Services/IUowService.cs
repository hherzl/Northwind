using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.DataLayer.Contracts;

namespace NorthwindWebApi2.Services
{
    public interface IBusinessObjectService
    {
        ISalesUow GetSalesUow();

        ISalesBusinessObject GetSalesBusinessObject();
    }
}
