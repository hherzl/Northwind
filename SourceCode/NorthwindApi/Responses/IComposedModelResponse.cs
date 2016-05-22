using System.Collections.Generic;

namespace NorthwindApi.Responses
{
    public interface IComposedModelResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }
}
