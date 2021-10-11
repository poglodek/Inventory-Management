using Inventory_Management.ViewModel;
using System.Windows;

namespace Inventory_Management
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            Window window = new MainWindow();
            window.DataContext = new MainWindowViewModel();
            window.Show();

            base.OnStartup(e);
        }

    }

}
