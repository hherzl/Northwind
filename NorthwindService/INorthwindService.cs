using System;
using System.Collections.Generic;
using System.ServiceModel;
using Northwind.Core.EntityLayer;

namespace NorthwindService
{
    [ServiceContract]
    public interface INorthwindService
    {
        [OperationContract]
        IEnumerable<Customer> GetCustomers();
    }
}
