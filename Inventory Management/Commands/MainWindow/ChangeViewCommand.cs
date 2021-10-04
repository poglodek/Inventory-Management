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
        private MainWindowViewModel viewModel;

        public ChangeViewCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
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
                    viewModel.ViewModel = new ItemsViewModel();
                    break;
                case "Clients":
                    viewModel.ViewModel = new ClientsViewModel();
                    break;
                case "FV":
                    viewModel.ViewModel = new FVViewModel();
                    break;
                case "MyData":
                    viewModel.ViewModel = new MyDataViewModel();
                    break;
                case "Stocktaking":
                    viewModel.ViewModel = new StockTakingViewModel();
                    break;
                case "Orders":
                    viewModel.ViewModel = new OrdersViewModel();
                    break;
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}
