using System.Runtime.Serialization;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class SingleRegionResponse : Response, ISingleViewModelResponse<Region>
    {
        public SingleRegionResponse()
        {

        }

        [DataMember(Name = "model")]
        public Region Model { get; set; }
    }
}
