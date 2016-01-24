namespace Northwind.Core.DataLayer.Contracts
{
    public interface IReportsUow : IUow
    {
        ICategorySaleFor1997Repository CategorySaleFor1997Repository { get; }
    }
}
