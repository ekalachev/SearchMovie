﻿using System;
using System.Collections.Generic;

namespace SearchMovie.Model.ResultModel
{
    public class Movie : MovieShort
    {
        public string Rated { get; set; }

        public DateTime Released { get; set; }

        public string Runtime { get; set; }

        public string Genre { get; set; }

        public string Director { get; set; }

        public string Writer { get; set; }

        public string Actors { get; set; }

        public string Plot { get; set; }

        public string Language { get; set; }

        public string Country { get; set; }

        public string Awards { get; set; }

        public IEnumerable<Rating> Ratings { get; set; }

        public string Metascore { get; set; }

        public string ImdbRating { get; set; }

        public string ImdbVotes { get; set; }

        public string Dvd { get; set; }

        public string BoxOffice { get; set; }

        public string Production { get; set; }

        public string Website { get; set; }

        public bool Response { get; set; }
    }
}
