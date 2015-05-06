using System;

namespace NorthwindWebApi2.Models
{
    public class ApiResult
    {
        public ApiResult()
        {

        }

        public Object Model { get; set; }

        public String Message { get; set; }

        public Boolean DidError { get; set; }

        public String ErrorMessage { get; set; }
    }
}
