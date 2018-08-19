using System;

namespace SearchMovie.Model.Search
{
    public class MovieIdModel
    {
        public MovieIdModel(string movieId)
        {
            if (string.IsNullOrWhiteSpace(movieId))
            {
                throw new ArgumentException(nameof(movieId));
            }

            MovieId = movieId;
        }

        public string MovieId { get; }
    }
}
