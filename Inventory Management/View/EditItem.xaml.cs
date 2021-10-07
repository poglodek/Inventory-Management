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
using Inventory_Management.ViewModel.Item;

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
