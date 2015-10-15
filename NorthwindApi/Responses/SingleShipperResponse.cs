using System;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    public class SingleShipperResponse : Response, ISingleShipperResponse
    {
        public SingleShipperResponse()
        {

        }

        public Shipper Single { get; set; }

        public Int32? Value { get; set; }
    }
}
