using System.Collections.Generic;
using System.Runtime.Serialization;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class ComposedRegionResponse: Response, IComposedViewModelResponse<Region>
    {
        public ComposedRegionResponse()
        {

        }

        [DataMember(Name = "model")]
        public IEnumerable<Region> Model { get; set; }
    }
}
