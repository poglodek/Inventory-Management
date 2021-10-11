using Inventory_Management.ViewModel.Order;
using System.Windows.Controls;


namespace Inventory_Management.View
{
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : UserControl
    {
        public Orders()
        {
            InitializeComponent();
            DataContext = new OrdersViewModel();
        }
    }
}
