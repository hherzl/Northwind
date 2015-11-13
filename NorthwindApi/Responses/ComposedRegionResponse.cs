using System.Collections.Generic;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    public class ComposedRegionResponse: Response, IComposedViewModelResponse<Region>
    {
        public ComposedRegionResponse()
        {

        }

        public IEnumerable<Region> Model { get; set; }
    }
}
