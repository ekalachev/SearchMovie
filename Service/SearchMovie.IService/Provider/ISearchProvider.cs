﻿using Core;
using RestSharp;
using SearchMovie.Model.ResultModel;

namespace SearchMovie.IService.Provider
{
    public interface ISearchProvider
    {
        Option<SearchResult> Execute(IRestRequest request);
    }
}
