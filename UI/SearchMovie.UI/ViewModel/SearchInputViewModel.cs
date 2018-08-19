using System.Windows.Input;
using Prism.Commands;
using SearchMovie.IService.ModelBuilder;
using SearchMovie.Model.Search;

namespace SearchMovie.UI.ViewModel
{
    public interface ISearchInputViewModel
    {
    }

    public class SearchInputViewModel : ISearchInputViewModel
    {
        private readonly ISearchResultModelBuilder _searchResultModelBuilder;
        private readonly ISearchResultViewModel _searchResultViewModel;

        public SearchInputViewModel(
            ISearchResultModelBuilder searchResultModelBuilder,
            ISearchResultViewModel searchResultViewModel)
        {
            _searchResultModelBuilder = searchResultModelBuilder;
            _searchResultViewModel = searchResultViewModel;

            SearchCommand = new DelegateCommand(OnSearchExecute);

            InvalidateCommands();
        }

        public ICommand SearchCommand { get; }

        public string SearchText { get; set; }

        private void OnSearchExecute()
        {
            _searchResultViewModel.Clear();

            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                var serarchModel = new SearchModel(SearchText);
                var searchResult = _searchResultModelBuilder.Build(serarchModel);

                _searchResultViewModel.Show(searchResult);
            }
        }

        private void InvalidateCommands()
        {
            ((DelegateCommand)SearchCommand).RaiseCanExecuteChanged();
        }
    }
}
