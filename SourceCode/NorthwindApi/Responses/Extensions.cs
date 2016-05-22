using System.Net;
using System.Net.Http;

namespace NorthwindApi.Responses
{
    public static class Extensions
    {
        public static HttpResponseMessage ToHttpResponse<TModel>(this IComposedModelResponse<TModel> composedModelResponse, HttpRequestMessage request)
        {
            var status = default(HttpStatusCode);

            if (composedModelResponse.DidError)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else
            {
                status = composedModelResponse.Model == null ? HttpStatusCode.NoContent : HttpStatusCode.OK;
            }

            return request.CreateResponse(status, composedModelResponse);
        }

        public static HttpResponseMessage ToHttpResponse<TModel>(this ISingleModelResponse<TModel> singleModelResponse, HttpRequestMessage request)
        {
            var status = default(HttpStatusCode);

            if (singleModelResponse.DidError)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else
            {
                status = singleModelResponse.Model == null ? HttpStatusCode.NotFound : HttpStatusCode.OK;
            }

            return request.CreateResponse(status, singleModelResponse);
        }
    }
}
