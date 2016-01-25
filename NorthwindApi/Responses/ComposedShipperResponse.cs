using System.Collections.Generic;
using System.Runtime.Serialization;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class ComposedShipperResponse : Response, IComposedViewModelResponse<Shipper>
    {
        public ComposedShipperResponse()
        {

        }

        [DataMember(Name = "model")]
        public IEnumerable<Shipper> Model { get; set; }
    }
}
