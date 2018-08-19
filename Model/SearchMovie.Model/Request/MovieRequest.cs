using System;

namespace SearchMovie.Model.Request
{
    public class MovieRequest : RequestBase
    {
        public MovieRequest(string apiKey, string movieId) : base(apiKey)
        {
            if (string.IsNullOrWhiteSpace(movieId))
            {
                throw new ArgumentException(nameof(movieId));
            }

            AddQueryParameter("i", movieId);
        }
    }
}
