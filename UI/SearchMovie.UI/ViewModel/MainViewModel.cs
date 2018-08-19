using System.ComponentModel;

namespace SearchMovie.UI.ViewModel
{
    public class MainViewModel : Observable
    {
        public MainViewModel(
            ISearchInputViewModel searchInputViewModel,
            ISearchResultViewModel searchResultViewModel)
        {
            SearchInputViewModel = searchInputViewModel;
            SearchResultViewModel = searchResultViewModel;
        }

        public ISearchInputViewModel SearchInputViewModel { get; private set; }

        public ISearchResultViewModel SearchResultViewModel { get; private set; }

        public void OnClosing(CancelEventArgs cancelEventArgs)
        {
            
        }
    }
}
