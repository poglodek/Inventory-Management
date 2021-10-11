using Inventory_Management.ViewModel.Item;
using System;
using System.Windows;

namespace Inventory_Management.View
{
    /// <summary>
    /// Interaction logic for EditItem.xaml
    /// </summary>
    public partial class EditItem : Window
    {
        public EditItem(Guid id)
        {
            InitializeComponent();
            DataContext = new EditItemViewModel(id);
        }
    }
}
