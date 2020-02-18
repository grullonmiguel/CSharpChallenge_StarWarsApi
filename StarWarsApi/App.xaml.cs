using StarWarsApi.ViewModels;
using StarWarsApi.Views;
using System.Windows;

namespace StarWarsApi
{
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var view = new ShellView { DataContext = new ShellViewModel()};

            view.ShowDialog();
        }
    }
}