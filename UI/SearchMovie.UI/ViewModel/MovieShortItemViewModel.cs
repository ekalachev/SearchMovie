using System.Windows.Input;
using Prism.Commands;
using SearchMovie.UI.Wrapper;

namespace SearchMovie.UI.ViewModel
{
    public class MovieShortItemViewModel : Observable
    {
        public MovieShortItemViewModel()
        {
            SelectMovieCommand = new DelegateCommand(OnSelectMovieExecute);
        }

        public MovieShortWrapper Model { get; set; }

        public ICommand SelectMovieCommand { get; }

        private void OnSelectMovieExecute()
        {
            //TODO open movie page
        }
    }
}
