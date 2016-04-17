using System.Collections.Generic;
using System.Runtime.Serialization;
using NorthwindApi.ViewModels;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class ComposedProductDetailResponse : Response, IComposedViewModelResponse<ProductDetailViewModel>
    {
        public ComposedProductDetailResponse()
        {

        }

        [DataMember(Name = "model")]
        public IEnumerable<ProductDetailViewModel> Model { get; set; }
    }
}
