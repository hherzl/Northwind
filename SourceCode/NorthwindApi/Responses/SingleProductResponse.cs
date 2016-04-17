using System.Runtime.Serialization;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class SingleProductResponse : Response, ISingleViewModelResponse<Product>
    {
        public SingleProductResponse()
        {

        }

        [DataMember(Name = "model")]
        public Product Model { get; set; }
    }
}
