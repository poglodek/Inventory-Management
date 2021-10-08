using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Inventory_Management.Model;
using Inventory_Management.View;
using Inventory_Management.ViewModel.Item;

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
                case "EditItem":
                    if (parameter is null) return;
                    new EditItem(((Item)parameter).Id).Show();
                    break;
                case "EditClient":
                    if (parameter is null) return;
                    new EditClient(((Client)parameter).Id).Show();
                    break;
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}
