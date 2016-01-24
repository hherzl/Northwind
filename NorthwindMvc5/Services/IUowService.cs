using Northwind.Core.DataLayer.Contracts;

namespace NorthwindMvc5.Services
{
    public interface IUowService
    {
        ISalesUow GetSalesUow();

        IReportsUow GetReportsUow();
    }
}
