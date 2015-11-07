using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    public class SingleShipperResponse : Response, ISingleViewModelResponse<Shipper>
    {
        public SingleShipperResponse()
        {

        }

        public Shipper Model { get; set; }
    }
}
