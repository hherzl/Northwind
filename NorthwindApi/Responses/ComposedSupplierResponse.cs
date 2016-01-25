using System.Collections.Generic;
using System.Runtime.Serialization;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class ComposedSupplierResponse : Response, IComposedViewModelResponse<Supplier>
    {
        public ComposedSupplierResponse()
        {

        }

        [DataMember(Name = "model")]
        public IEnumerable<Supplier> Model { get; set; }
    }
}
