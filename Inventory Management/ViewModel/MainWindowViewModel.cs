using Inventory_Management.Commands;
using Inventory_Management.ViewModel.Base;
using Inventory_Management.ViewModel.Item;
using System.Windows.Input;

namespace Inventory_Management.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        private ViewModelBase viewModel;

        public MainWindowViewModel()
        {
            UpdateViewCommand = new ChangeViewCommand(this);
            viewModel = new ItemsViewModel();
        }
        public ViewModelBase ViewModel
        {
            get => viewModel;
            set
            {
                viewModel = value;
                OnPropertyChanged(nameof(ViewModel));
            }
        }
        public ICommand UpdateViewCommand { get; set; }

    }
}
