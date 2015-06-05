using Northwind.Core.DataLayer;
using Northwind.Core.DataLayer.OperationContracts;

namespace NorthwindWebApi2.Services
{
    public class UowService : IUowService
    {
        public ISalesUow GetSalesUow()
        {
            return new SalesUow(new SalesDbContext());
        }
    }
}
