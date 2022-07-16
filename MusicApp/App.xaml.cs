using MusicApp.MVVM.ViewModel;
using System.Windows;

namespace MusicApp
{

    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow();
            {
                //DataContext = new MainViewModel();
            }
            MainWindow.Show();
            base.OnStartup(e);


        }
    }
}
