namespace NorthwindApi.Responses
{
    public interface ISingleViewModelResponse<TViewModel> : IResponse
    {
        TViewModel Model { get; set; }
    }
}
