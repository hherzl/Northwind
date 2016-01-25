using System.Runtime.Serialization;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.Responses
{
    [DataContract]
    public class SingleEmployeeResponse : Response, ISingleViewModelResponse<Employee>
    {
        public SingleEmployeeResponse()
        {

        }

        [DataMember(Name = "model")]
        public Employee Model { get; set; }
    }
}
