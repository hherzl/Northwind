using NorthwindApi.ViewModels;

namespace NorthwindApi.Responses
{
    public class SingleCategoryResponse : Response, ISingleViewModelResponse<CategoryViewModel>
    {
        public SingleCategoryResponse()
        {

        }

        public CategoryViewModel Model { get; set; }
    }
}
