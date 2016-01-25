using Northwind.Core.BusinessLayer;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.DataLayer;
using Northwind.Core.DataLayer.Contracts;

namespace NorthwindApi.Services
{
    public class UowService : IUowService
    {
        public ISalesUow GetSalesUow()
        {
            return new SalesUow(new SalesDbContext());
        }

        public ISalesBusinessObject GetSalesBusinessObject()
        {
            return new SalesBusinessObject(new SalesUow(new SalesDbContext()));
        }
    }
}
