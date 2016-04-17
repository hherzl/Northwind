using System;
using System.Collections.Generic;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Contracts
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<CustOrderHist> GetCustOrderHist(String customerID);
    }
}
