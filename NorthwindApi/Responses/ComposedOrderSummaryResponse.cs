using System.Collections.Generic;
using System.Runtime.Serialization;
using NorthwindApi.ViewModels;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class ComposedOrderSummaryResponse : Response, IComposedViewModelResponse<OrderSummaryViewModel>
    {
        public ComposedOrderSummaryResponse()
        {

        }

        [DataMember(Name = "model")]
        public IEnumerable<OrderSummaryViewModel> Model { get; set; }
    }
}
