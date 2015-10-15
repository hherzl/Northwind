using System;

namespace NorthwindApi.Responses
{
    public class Response
    {
        public String Message { get; set; }

        public Boolean DidError { get; set; }

        public String ErrorMessage { get; set; }
    }
}
