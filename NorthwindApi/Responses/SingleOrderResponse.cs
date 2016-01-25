using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    public class SingleOrderResponse : Response, ISingleViewModelResponse<Order>
    {
        public SingleOrderResponse()
        {

        }

        public Order Model { get; set; }
    }
}
