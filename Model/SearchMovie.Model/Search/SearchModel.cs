using System;

namespace SearchMovie.Model.Search
{
    public class SearchModel
    {
        public SearchModel(string filmTitle)
        {
            if (string.IsNullOrWhiteSpace(filmTitle))
            {
                throw new ArgumentException();
            }

            FilmTitle = filmTitle;
        }

        public string FilmTitle { get; }
    }
}
