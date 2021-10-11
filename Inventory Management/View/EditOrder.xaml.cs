using Inventory_Management.ViewModel.Order;
using System;
using System.Windows;

namespace Inventory_Management.View
{
    /// <summary>
    /// Interaction logic for EditOrder.xaml
    /// </summary>
    public partial class EditOrder : Window
    {
        public EditOrder(Guid id)
        {
            InitializeComponent();

            DataContext = new EditOrderViewModel(id);
        }
    }
}
