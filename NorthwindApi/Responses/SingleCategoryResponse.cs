using System.Runtime.Serialization;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class SingleCategoryResponse : Response, ISingleViewModelResponse<Category>
    {
        public SingleCategoryResponse()
        {

        }

        [DataMember(Name = "model")]
        public Category Model { get; set; }
    }
}
