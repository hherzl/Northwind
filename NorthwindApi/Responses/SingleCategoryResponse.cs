using System.Runtime.Serialization;
using NorthwindApi.ViewModels;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class SingleCategoryResponse : Response, ISingleViewModelResponse<CategoryViewModel>
    {
        public SingleCategoryResponse()
        {

        }

        [DataMember(Name = "model")]
        public CategoryViewModel Model { get; set; }
    }
}
