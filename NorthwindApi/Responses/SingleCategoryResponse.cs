using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    public class SingleCategoryResponse : Response, ISingleViewModelResponse<Category>
    {
        public SingleCategoryResponse()
        {

        }

        public Category Model { get; set; }
    }
}
