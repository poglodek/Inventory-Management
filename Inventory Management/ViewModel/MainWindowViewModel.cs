using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management.ViewModel.Base;

namespace Inventory_Management.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase viewModel = new ItemsViewModel();

        public ViewModelBase ViewModel
        {
            get => viewModel;
            set => viewModel = value;
        }
    }
}
