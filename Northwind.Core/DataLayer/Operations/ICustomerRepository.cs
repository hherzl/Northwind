using System;
using System.Collections.Generic;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Operations
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<CustOrderHist> GetCustOrderHist(String customerID);
    }
}
