using System;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    public interface ISingleShipperResponse : IResponse
    {
        Shipper Single { get; set; }

        Int32? Value { get; set; }
    }
}
