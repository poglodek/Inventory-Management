using Inventory_Management.Model;
using Inventory_Management.View;
using System;
using System.Windows.Input;

namespace Inventory_Management.Commands
{
    public class OpenNewWindowCommand : ICommand
    {
        private readonly string _viewName;

        public OpenNewWindowCommand(string viewName)
        {
            _viewName = viewName;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (_viewName is null) return;
            switch (_viewName)
            {
                case "AddItem":
                    new AddItem().Show();
                    break;
                case "AddClient":
                    new AddClient().Show();
                    break;
                case "AddOrder":
                    new AddOrder().Show();
                    break;
                case "EditItem":
                    if (parameter is null) return;
                    new EditItem(((Item)parameter).Id).Show();
                    break;
                case "EditClient":
                    if (parameter is null) return;
                    new EditClient(((Client)parameter).Id).Show();
                    break;
                case "EditOrder":
                    if (parameter is null) return;
                    new EditOrder(((Order)parameter).Id).Show();
                    break;
                case "Order":
                    if (parameter is null) return;
                    new OrderView(((Order)parameter).Id).Show();
                    break;
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}
