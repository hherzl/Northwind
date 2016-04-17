using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using Northwind.Core.EntityLayer;

namespace NorthwindService
{
    [ServiceContract]
    public interface INorthwindService
    {
        [OperationContract]
        Task<IEnumerable<Customer>> GetCustomers();

        [OperationContract]
        Task AddCustomer(Customer entity);

        [OperationContract]
        Task<Customer> GetCustomer(String customerID);
    }
}
