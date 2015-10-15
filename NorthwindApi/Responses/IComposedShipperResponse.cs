using System.Collections.Generic;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    public interface IComposedShipperResponse : IResponse
    {
        IEnumerable<Shipper> Model { get; set; }
    }
}
