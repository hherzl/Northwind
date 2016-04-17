using System.Collections.Generic;
using System.Runtime.Serialization;
using NorthwindApi.ViewModels;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class ComposedCategoryResponse : Response, IComposedViewModelResponse<CategoryViewModel>
    {
        public ComposedCategoryResponse()
        {

        }

        [DataMember(Name = "model")]
        public IEnumerable<CategoryViewModel> Model { get; set; }
    }
}
