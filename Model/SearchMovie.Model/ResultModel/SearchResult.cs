using System.Collections.Generic;
using Core;

namespace SearchMovie.Model.ResultModel
{
    public class SearchResult
    {
        public IEnumerable<MovieShort> Search { get; set; }

        public int TotalResults { get; set; }

        public bool Response { get; set; }
    }
}
