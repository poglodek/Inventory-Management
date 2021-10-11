using Inventory_Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Inventory_Management.Commands
{
    public class AddItemToListCommand : ICommand
    {
        private readonly List<Item> _selectedItems;
        private readonly Item _selectedItem;

        public AddItemToListCommand(List<Item> selectedItems, Item selectedItem)
        {
            _selectedItems = selectedItems;
            _selectedItem = selectedItem;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (_selectedItems.Any(x => x.Id.Equals(_selectedItem.Id)))
                _selectedItems.Where(x => x.Id.Equals(_selectedItem.Id)).FirstOrDefault().Count++;
            else
            {
                _selectedItem.Count = 1;
                _selectedItems.Add(_selectedItem);
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}
