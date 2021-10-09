using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Inventory_Management.ViewModel.Order;

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
