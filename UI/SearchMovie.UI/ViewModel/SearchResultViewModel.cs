using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using SearchMovie.Model.ResultModel;
using SearchMovie.UI.Wrapper;

namespace SearchMovie.UI.ViewModel
{
    public interface ISearchResultViewModel
    {
        void Show(SearchResult searchResult);
    }

    public class SearchResultViewModel : ISearchResultViewModel
    {
        public SearchResultViewModel()
        {
            MovieItems = new ObservableCollection<MovieShortItemViewModel>();
        }

        public ObservableCollection<MovieShortItemViewModel> MovieItems { get; set; }

        public void Show(SearchResult searchResult)
        {
            MovieItems.Clear();

            if (searchResult.Response)
            {
                foreach (var model in searchResult.Search)
                {
                    var wrapper = new MovieShortWrapper(model);
                    MovieItems.Add(new MovieShortItemViewModel(wrapper));
                }
            }
        }
    }
}
