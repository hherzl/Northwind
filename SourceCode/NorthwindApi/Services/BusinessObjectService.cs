using Northwind.Core.BusinessLayer;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.DataLayer;

namespace NorthwindApi.Services
{
    public class BusinessObjectService : IBusinessObjectService
    {
        public ISalesBusinessObject GetSalesBusinessObject()
        {
            return new SalesBusinessObject(new SalesUow(new SalesDbContext()));
        }

        public IStoreBusinessObject GetStoreBusinessObject()
        {
            return new StoreBusinessObject(new StoreUow(new SalesDbContext()));
        }
    }
}
