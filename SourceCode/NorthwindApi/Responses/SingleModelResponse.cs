using System;
using System.Runtime.Serialization;

namespace NorthwindApi.Responses
{
    public class SingleModelResponse<TModel> : ISingleModelResponse<TModel>
    {
        public SingleModelResponse()
        {

        }

        [DataMember(Name = "message")]
        public String Message { get; set; }

        [DataMember(Name = "didError")]
        public Boolean DidError { get; set; }

        [DataMember(Name = "errorMessage")]
        public String ErrorMessage { get; set; }

        [DataMember(Name = "model")]
        public TModel Model { get; set; }
    }
}
