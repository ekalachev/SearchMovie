using System.Windows;
using Autofac;
using SearchMovie.UI.Startup;
using SearchMovie.UI.View;
using SearchMovie.UI.ViewModel;

namespace SearchMovie.UI
{
    public partial class App : Application
    {
        private MainViewModel _mainViewModel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bootstrapper = new Bootstrapper();
            IContainer container = bootstrapper.Bootstrap();

            _mainViewModel = container.Resolve<MainViewModel>();
            MainWindow = new MainWindow(_mainViewModel);
            MainWindow.Show();
        }
    }
}
