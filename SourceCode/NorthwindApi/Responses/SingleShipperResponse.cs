using System.Runtime.Serialization;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class SingleShipperResponse : Response, ISingleViewModelResponse<Shipper>
    {
        public SingleShipperResponse()
        {

        }

        [DataMember(Name = "model")]
        public Shipper Model { get; set; }
    }
}
