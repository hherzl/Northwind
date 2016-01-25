using System.Runtime.Serialization;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class SingleOrderResponse : Response, ISingleViewModelResponse<Order>
    {
        public SingleOrderResponse()
        {

        }

        [DataMember(Name = "model")]
        public Order Model { get; set; }
    }
}
