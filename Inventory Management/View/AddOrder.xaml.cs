using Inventory_Management.ViewModel.Order;
using System.Windows;

namespace Inventory_Management.View
{
    /// <summary>
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        public AddOrder()
        {
            InitializeComponent();

            DataContext = new AddOrderViewModel();
        }
    }
}
