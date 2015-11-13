using System.Collections.Generic;
using NorthwindApi.ViewModels;

namespace NorthwindApi.Responses
{
    public class ComposedCategoryResponse : Response, IComposedViewModelResponse<CategoryViewModel>
    {
        public ComposedCategoryResponse()
        {

        }

        public IEnumerable<CategoryViewModel> Model { get; set; }
    }
}
