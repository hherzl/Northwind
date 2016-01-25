using System.Runtime.Serialization;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class SingleSupplierResponse : Response, ISingleViewModelResponse<Supplier>
    {
        public SingleSupplierResponse()
        {

        }

        [DataMember(Name = "model")]
        public Supplier Model { get; set; }
    }
}
