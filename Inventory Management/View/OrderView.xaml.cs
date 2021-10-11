using Inventory_Management.ViewModel.Order;
using System;
using System.Windows;

namespace Inventory_Management.View
{
    /// <summary>
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : Window
    {
        public OrderView(Guid id)
        {
            InitializeComponent();

            DataContext = new OrderViewViewModel(id);
        }
    }
}
