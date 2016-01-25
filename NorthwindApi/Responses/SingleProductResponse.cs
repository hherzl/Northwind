using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    public class SingleProductResponse : Response, ISingleViewModelResponse<Product>
    {
        public SingleProductResponse()
        {

        }

        public Product Model { get; set; }
    }
}
