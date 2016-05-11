using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class ComposedViewModelResponse<TViewModel> : IComposedViewModelResponse<TViewModel>
    {
        public ComposedViewModelResponse()
        {

        }

        [DataMember(Name = "message")]
        public String Message { get; set; }

        [DataMember(Name = "didError")]
        public Boolean DidError { get; set; }

        [DataMember(Name = "errorMessage")]
        public String ErrorMessage { get; set; }

        [DataMember(Name = "model")]
        public IEnumerable<TViewModel> Model { get; set; }
    }
}
