using Northwind.Core.BusinessLayer;

namespace NorthwindMvc5.Services
{
    public interface IUowService
    {
        ISalesUow GetSalesUow();
    }
}
