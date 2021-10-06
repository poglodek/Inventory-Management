using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Inventory_Management.ViewModel;

namespace Inventory_Management.Commands.MainWindow
{
    public class ChangeViewCommand : ICommand
    {
        private readonly MainWindowViewModel _viewModel;

        public ChangeViewCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            switch (parameter.ToString())
            {
                case "Items":
                    _viewModel.ViewModel = new ItemsViewModel();
                    break;
                case "Clients":
                    _viewModel.ViewModel = new ClientsViewModel();
                    break;
                case "FV":
                    _viewModel.ViewModel = new FVViewModel();
                    break;
                case "MyData":
                    _viewModel.ViewModel = new MyDataViewModel();
                    break;
                case "Stocktaking":
                    _viewModel.ViewModel = new StockTakingViewModel();
                    break;
                case "Orders":
                    _viewModel.ViewModel = new OrdersViewModel();
                    break;
            }
                
            
        }

        public event EventHandler? CanExecuteChanged;
    }
}
