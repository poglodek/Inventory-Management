using Inventory_Management.ViewModel.Item;
using System.Windows.Controls;


namespace Inventory_Management.View
{
    /// <summary>
    /// Interaction logic for Items.xaml
    /// </summary>
    public partial class Items : UserControl
    {
        public Items()
        {
            InitializeComponent();
            DataContext = new ItemsViewModel();
        }

    }
}
