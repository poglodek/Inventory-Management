using Inventory_Management.ViewModel;
using System.Windows.Controls;

namespace Inventory_Management.View
{
    /// <summary>
    /// Interaction logic for MyData.xaml
    /// </summary>
    public partial class MyData : UserControl
    {
        public MyData()
        {
            InitializeComponent();
            DataContext = new MyDataViewModel();
        }
    }
}
