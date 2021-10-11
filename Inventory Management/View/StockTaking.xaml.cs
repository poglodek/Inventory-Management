using Inventory_Management.ViewModel;
using System.Windows.Controls;

namespace Inventory_Management.View
{
    /// <summary>
    /// Interaction logic for StockTaking.xaml
    /// </summary>
    public partial class StockTaking : UserControl
    {
        public StockTaking()
        {
            InitializeComponent();

            DataContext = new StockTakingViewModel();
        }
    }
}
