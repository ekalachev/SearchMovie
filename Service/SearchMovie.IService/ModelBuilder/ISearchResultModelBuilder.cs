﻿using Core;
using SearchMovie.Model.ResultModel;
using SearchMovie.Model.Search;

namespace SearchMovie.IService.ModelBuilder
{
    public interface ISearchResultModelBuilder
    {
        Option<SearchResult> Build(SearchModel searchModel);
    }
}
