using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Inventory_Management.Database;
using Inventory_Management.Model;
using Inventory_Management.ViewModel.Base;

namespace Inventory_Management.Commands
{
    public class AddOrderCommand<T> : ICommand where T : BaseEntity
    {
        private readonly DocumentViewModel<T> _documentViewModel;
        private readonly ViewModelBase _viewModelBase;
        private readonly MongoDb _mongoDb;
        private readonly string _collectionName;
        private readonly List<Item> _items;

        public AddOrderCommand(DocumentViewModel<T> documentViewModel, ViewModelBase viewModelBase, MongoDb mongoDb, string collectionName, List<Item> items)
        {
            _documentViewModel = documentViewModel;
            _viewModelBase = viewModelBase;
            _mongoDb = mongoDb;
            _collectionName = collectionName;
            _items = items;
        }

        public bool CanExecute(object? parameter) => true;//_viewModelBase.HasErrors;

        public void Execute(object? parameter)
        {
            
        }

        public event EventHandler? CanExecuteChanged;
    }
}
