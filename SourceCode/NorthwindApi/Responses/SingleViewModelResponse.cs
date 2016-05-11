using System;
using System.Runtime.Serialization;

namespace NorthwindApi.Responses
{
    public class SingleViewModelResponse<TViewModel> : ISingleViewModelResponse<TViewModel>
    {
        public SingleViewModelResponse()
        {

        }

        [DataMember(Name = "message")]
        public String Message { get; set; }

        [DataMember(Name = "didError")]
        public Boolean DidError { get; set; }

        [DataMember(Name = "errorMessage")]
        public String ErrorMessage { get; set; }

        [DataMember(Name = "model")]
        public TViewModel Model { get; set; }
    }
}
