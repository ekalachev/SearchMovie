using System.Collections.ObjectModel;
using Core;
using SearchMovie.Model.ResultModel;
using SearchMovie.UI.Wrapper;

namespace SearchMovie.UI.ViewModel
{
    public interface ISearchResultViewModel
    {
        void Clear();

        void Show(Option<SearchResult> searchResult);
    }

    public class SearchResultViewModel : ISearchResultViewModel
    {
        public SearchResultViewModel()
        {
            MovieItems = new ObservableCollection<MovieShortItemViewModel>();
        }

        public ObservableCollection<MovieShortItemViewModel> MovieItems { get; set; }

        public void Clear()
        {
            MovieItems.Clear();
        }

        public void Show(Option<SearchResult> searchResult)
        {
            searchResult.Do(result =>
            {
                if (result.Response)
                {
                    foreach (var model in result.Search)
                    {
                        var wrapper = new MovieShortWrapper(model);
                        MovieItems.Add(new MovieShortItemViewModel { Model = wrapper });
                    }
                }
            });
        }
    }
}
