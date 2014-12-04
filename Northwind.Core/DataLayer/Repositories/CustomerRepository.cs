using System.Data.Entity;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.PocoLayer;

namespace Northwind.Core.DataLayer.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
