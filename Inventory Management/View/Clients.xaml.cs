using Inventory_Management.ViewModel.Client;
using System.Windows.Controls;

namespace Inventory_Management.View
{
    /// <summary>
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : UserControl
    {
        public Clients()
        {
            InitializeComponent();
            DataContext = new ClientsViewModel();
        }
    }
}
