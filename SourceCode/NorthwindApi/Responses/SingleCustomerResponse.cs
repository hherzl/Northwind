using System.Runtime.Serialization;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class SingleCustomerResponse : Response, ISingleViewModelResponse<Customer>
    {
        public SingleCustomerResponse()
        {

        }

        [DataMember(Name = "model")]
        public Customer Model { get; set; }
    }
}
