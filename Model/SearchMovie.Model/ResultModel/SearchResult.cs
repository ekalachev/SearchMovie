using System.Collections.Generic;

namespace SearchMovie.Model.ResultModel
{
    public class SearchResult
    {
        public IEnumerable<MovieShort> Search { get; set; }

        public int TotalResults { get; set; }

        public bool Response { get; set; }
    }
}
