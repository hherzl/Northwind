using System;

namespace NorthwindWebApi2.Models
{
    public class ApiResponse : IApiResponse
    {
        public ApiResponse()
        {

        }
        
        public Object Model { get; set; }

        public String Message { get; set; }

        public Boolean DidError { get; set; }

        public String ErrorMessage { get; set; }
    }
}
