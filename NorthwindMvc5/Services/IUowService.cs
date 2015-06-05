using Northwind.Core.DataLayer.OperationContracts;

namespace NorthwindMvc5.Services
{
    public interface IUowService
    {
        ISalesUow GetSalesUow();
    }
}
