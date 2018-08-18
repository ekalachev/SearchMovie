using System;
using System.ComponentModel;
using Prism.Events;

namespace SearchMovie.UI.ViewModel
{
    public class MainViewModel : Observable
    {
        private readonly IEventAggregator _eventAggregator;

        public MainViewModel(
            IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void Load()
        {
        }

        public void OnClosing(CancelEventArgs cancelEventArgs)
        {
            throw new NotImplementedException();
        }
    }
}
