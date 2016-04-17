using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public IEnumerable<CustOrderHist> GetCustOrderHist(String customerID)
        {
            var sql = "exec [CustOrderHist] @CustomerID ";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", customerID)
            };

            return DbContext
                .Database
                .SqlQuery<CustOrderHist>(sql, parameters);
        }

        public override Customer Get(Customer entity)
        {
            return DbSet
                .FirstOrDefault(item => item.CustomerID == entity.CustomerID);
        }
    }
}
