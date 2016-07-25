namespace Northwind.Core.DataLayer.Contracts
{
    public interface IStoreUow : IUow
    {
        IProductRepository ProductRepository { get; }

        IShoppingCartRepository ShoppingCartRepository { get; }

        IShoppingCartItemRepository ShoppingCartItemRepository { get; }
    }
}
