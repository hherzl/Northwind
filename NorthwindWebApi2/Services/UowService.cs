using Northwind.Core.BusinessLayer;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.DataLayer;
using Northwind.Core.DataLayer.Contracts;

namespace NorthwindWebApi2.Services
{
    public class BusinessObjectService : IBusinessObjectService
    {
        public ISalesUow GetSalesUow()
        {
            return new SalesUow(new SalesDbContext());
        }

        public ISalesBusinessObject GetSalesBusinessObject()
        {
            return new SalesBusinessObject(new SalesUow(new SalesDbContext()) as ISalesUow);
        }
    }
}
