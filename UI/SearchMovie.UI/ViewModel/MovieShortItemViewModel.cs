using System.Windows.Input;
using Prism.Commands;
using SearchMovie.UI.Wrapper;

namespace SearchMovie.UI.ViewModel
{
    public class MovieShortItemViewModel : Observable
    {
        public MovieShortItemViewModel(MovieShortWrapper movieShortWrapper)
        {
            Model = movieShortWrapper;

            SelectMovieCommand = new DelegateCommand(OnSelectMovieExecute);
        }

        public MovieShortWrapper Model { get; private set; }

        public ICommand SelectMovieCommand { get; private set; }

        private void OnSelectMovieExecute()
        {
            
        }
    }
}
