using Inventory_Management.ViewModel;
using Inventory_Management.ViewModel.Client;
using Inventory_Management.ViewModel.Item;
using Inventory_Management.ViewModel.Order;
using System;
using System.Windows.Input;

namespace Inventory_Management.Commands
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
