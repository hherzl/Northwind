using Northwind.Core.BusinessLayer.Contracts;

namespace NorthwindApi.Services
{
    public interface IBusinessObjectService
    {
        ISalesBusinessObject GetSalesBusinessObject();

        IStoreBusinessObject GetStoreBusinessObject();
    }
}
