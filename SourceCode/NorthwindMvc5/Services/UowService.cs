using Northwind.Core.DataLayer;
using Northwind.Core.DataLayer.Contracts;

namespace NorthwindMvc5.Services
{
    public class UowService : IUowService
    {
        public ISalesUow GetSalesUow()
        {
            return new SalesUow(new SalesDbContext());
        }

        public IReportsUow GetReportsUow()
        {
            return new ReportsUow(new SalesDbContext());
        }
    }
}
