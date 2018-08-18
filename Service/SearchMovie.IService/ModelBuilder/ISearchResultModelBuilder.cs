using SearchMovie.Model.ResultModel;
using SearchMovie.Model.Search;

namespace SearchMovie.IService.ModelBuilder
{
    public interface ISearchResultModelBuilder
    {
        SearchResult Build(SearchModel searchModel);
    }
}
