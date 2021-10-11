using Inventory_Management.ViewModel;
using System.Windows.Controls;


namespace Inventory_Management.View
{
    /// <summary>
    /// Interaction logic for FV.xaml
    /// </summary>
    public partial class FV : UserControl
    {
        public FV()
        {
            InitializeComponent();
            DataContext = new FVViewModel();
        }
    }
}
