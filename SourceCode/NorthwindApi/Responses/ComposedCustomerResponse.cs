using System.Collections.Generic;
using System.Runtime.Serialization;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class ComposedCustomerResponse : Response, IComposedViewModelResponse<Customer>
    {
        public ComposedCustomerResponse()
        {

        }

        [DataMember(Name = "model")]
        public IEnumerable<Customer> Model { get; set; }
    }
}
