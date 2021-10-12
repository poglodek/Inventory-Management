using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Inventory_Management.Model;
using Inventory_Management.Services;
using Inventory_Management.ViewModel;

namespace Inventory_Management.Commands
{
    public class GenerateFVCommand : ICommand
    {
        private readonly FVViewModel _viewModel;
        private readonly IFVServices fVServices;

        public GenerateFVCommand(FVViewModel  viewModel)
        {
            _viewModel = viewModel;
            fVServices = new FVServices();
        }
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            fVServices.CreateFV(_viewModel.SelectedItem);
        }

        public event EventHandler? CanExecuteChanged;
    }
}
