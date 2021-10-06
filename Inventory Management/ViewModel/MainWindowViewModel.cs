using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Inventory_Management.Commands.MainWindow;
using Inventory_Management.ViewModel.Base;

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
