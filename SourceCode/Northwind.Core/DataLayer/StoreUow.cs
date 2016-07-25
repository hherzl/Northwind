using System.Data.Entity;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.DataLayer.Repositories;

namespace Northwind.Core.DataLayer
{
    public class StoreUow : Uow, IStoreUow
    {
        private IProductRepository m_productRepository;
        private IShoppingCartRepository m_shoppingCartRepository;
        private IShoppingCartItemRepository m_shoppingCartItemRepository;

        public StoreUow(DbContext dbContext)
            : base(dbContext)
        {
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return m_productRepository ?? (m_productRepository = new ProductRepository(DbContext));
            }
        }

        public IShoppingCartRepository ShoppingCartRepository
        {
            get
            {
                return m_shoppingCartRepository ?? (m_shoppingCartRepository = new ShoppingCartRepository(DbContext));
            }
        }

        public IShoppingCartItemRepository ShoppingCartItemRepository
        {
            get
            {
                return m_shoppingCartItemRepository ?? (m_shoppingCartItemRepository = new ShoppingCartItemRepository(DbContext));
            }
        }
    }
}
