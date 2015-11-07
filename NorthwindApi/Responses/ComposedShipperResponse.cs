using System.Collections.Generic;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    public class ComposedShipperResponse : Response, IComposedViewModelResponse<Shipper>
    {
        public ComposedShipperResponse()
        {

        }

        public IEnumerable<Shipper> Model { get; set; }
    }
}
