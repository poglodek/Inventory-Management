using Inventory_Management.ViewModel.Client;
using System.Windows;

namespace Inventory_Management.View
{
    /// <summary>
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();

            DataContext = new ClientViewModel();
        }
    }
}
