using System;
using RestSharp;

namespace SearchMovie.Model.Request
{
    public abstract class RequestBase : RestRequest
    {
        protected RequestBase(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException(nameof(apiKey));
            }

            AddQueryParameter("apikey", apiKey);

            Method = Method.GET;
        }
    }
}
