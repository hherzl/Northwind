using Northwind.Core.BusinessLayer;
using Northwind.Core.DataLayer;

namespace NorthwindMvc5.Services
{
    public class UowService : IUowService
    {
        public ISalesUow GetSalesUow()
        {
            var dbContext = new SalesDbContext();

            return new SalesUow(dbContext);
        }
    }
}
