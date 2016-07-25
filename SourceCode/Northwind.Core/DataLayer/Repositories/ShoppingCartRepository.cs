using System;
using System.Data.Entity;
using System.Linq;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public ShoppingCart GetByCustomerID(String customerID)
        {
            return DbSet.FirstOrDefault(item => item.CustomerID == customerID);
        }
    }
}
