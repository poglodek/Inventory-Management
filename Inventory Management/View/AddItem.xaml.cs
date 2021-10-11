using Inventory_Management.ViewModel.Item;
using System.Windows;

namespace Inventory_Management.View
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        public AddItem()
        {
            InitializeComponent();
            DataContext = new ItemViewModel();
        }
    }
}
