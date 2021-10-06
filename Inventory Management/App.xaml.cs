using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Inventory_Management.ViewModel;
using Inventory_Management.ViewModel.Base;
using Microsoft.Extensions.DependencyInjection;

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
