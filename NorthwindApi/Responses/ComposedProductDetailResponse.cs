using System.Collections.Generic;
using NorthwindApi.ViewModels;

namespace NorthwindApi.Responses
{
    public class ComposedProductDetailResponse : Response, IComposedViewModelResponse<ProductDetailViewModel>
    {
        public ComposedProductDetailResponse()
        {

        }

        public IEnumerable<ProductDetailViewModel> Model { get; set; }
    }
}
