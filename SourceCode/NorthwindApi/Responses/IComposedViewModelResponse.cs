using System.Collections.Generic;

namespace NorthwindApi.Responses
{
    public interface IComposedViewModelResponse<TViewModel> : IResponse
    {
        IEnumerable<TViewModel> Model { get; set; }
    }
}
