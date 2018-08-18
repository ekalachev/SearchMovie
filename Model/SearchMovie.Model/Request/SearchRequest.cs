using System;

namespace SearchMovie.Model.Request
{
    public class SearchRequest : RequestBase
    {
        public SearchRequest(string apiKey, string filmTitle) : base(apiKey)
        {
            if (string.IsNullOrWhiteSpace(filmTitle))
            {
                throw new ArgumentException(nameof(filmTitle));
            }

            AddQueryParameter("s", filmTitle);
        }
    }
}
