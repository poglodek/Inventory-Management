using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Inventory_Management.View;

namespace Inventory_Management.Commands
{
    public class AddDocumentViewCommand : ICommand
    {
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is null) return;
            switch (parameter as string)
            {
                case "AddItem":
                    new AddItem().Show();
                    break;
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}
