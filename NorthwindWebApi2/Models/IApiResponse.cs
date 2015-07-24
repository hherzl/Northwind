using System;

namespace NorthwindWebApi2.Models
{
    public interface IApiResponse
    {
        Object Model { get; set; }

        String Message { get; set; }

        Boolean DidError { get; set; }

        String ErrorMessage { get; set; }
    }
}
