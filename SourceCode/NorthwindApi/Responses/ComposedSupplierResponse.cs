using System.Collections.Generic;
using System.Runtime.Serialization;
using NorthwindApi.ViewModels;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class ComposedSupplierResponse : Response, IComposedViewModelResponse<SupplierDetailViewModel>
    {
        public ComposedSupplierResponse()
        {

        }

        [DataMember(Name = "model")]
        public IEnumerable<SupplierDetailViewModel> Model { get; set; }
    }
}
