using Inventory_Management.ViewModel.Client;
using System;
using System.Windows;

namespace Inventory_Management.View
{
    /// <summary>
    /// Interaction logic for EditClient.xaml
    /// </summary>
    public partial class EditClient : Window
    {
        public EditClient(Guid id)
        {
            InitializeComponent();

            DataContext = new EditClientViewModel(id);
        }
    }
}
