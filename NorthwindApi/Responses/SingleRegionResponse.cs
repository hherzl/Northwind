using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    public class SingleRegionResponse : Response, ISingleViewModelResponse<Region>
    {
        public SingleRegionResponse()
        {

        }

        public Region Model { get; set; }
    }
}
