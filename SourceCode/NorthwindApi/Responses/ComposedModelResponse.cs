using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class ComposedModelResponse<TModel> : IComposedModelResponse<TModel>
    {
        public ComposedModelResponse()
        {

        }

        [DataMember(Name = "message")]
        public String Message { get; set; }

        [DataMember(Name = "didError")]
        public Boolean DidError { get; set; }

        [DataMember(Name = "errorMessage")]
        public String ErrorMessage { get; set; }

        [DataMember(Name = "model")]
        public IEnumerable<TModel> Model { get; set; }
    }
}
