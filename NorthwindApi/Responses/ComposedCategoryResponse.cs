using System.Collections.Generic;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    public class ComposedCategoryResponse: Response, IComposedViewModelResponse<Category>
    {
        public ComposedCategoryResponse()
        {

        }

        public IEnumerable<Category> Model { get; set; }
    }
}
