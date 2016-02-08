using System;
using Newtonsoft.Json;

namespace NorthwindApi.Responses
{
    public class Response
    {
        [JsonProperty]
        public String Message { get; set; }

        [JsonProperty]
        public Boolean DidError { get; set; }

        [JsonProperty]
        public String ErrorMessage { get; set; }
    }
}
