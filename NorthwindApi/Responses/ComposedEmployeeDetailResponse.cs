using System.Collections.Generic;
using System.Runtime.Serialization;
using NorthwindApi.ViewModels;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class ComposedEmployeeDetailResponse : Response, IComposedViewModelResponse<EmployeeDetailViewModel>
    {
        public ComposedEmployeeDetailResponse()
        {

        }

        [DataMember(Name = "model")]
        public IEnumerable<EmployeeDetailViewModel> Model { get; set; }
    }
}
