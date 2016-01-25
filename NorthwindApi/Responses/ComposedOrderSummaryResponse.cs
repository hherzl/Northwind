using System.Collections.Generic;
using NorthwindApi.ViewModels;

namespace NorthwindApi.Responses
{
    public class ComposedOrderSummaryResponse : Response, IComposedViewModelResponse<OrderSummaryViewModel>
    {
        public ComposedOrderSummaryResponse()
        {

        }

        public IEnumerable<OrderSummaryViewModel> Model { get; set; }
    }
}
