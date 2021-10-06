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
    public class AddDocumentCommand<T> : ICommand
    {
        private readonly AddDocumentViewModel<T> _documentViewModel;
        private readonly ViewModelBase _viewModelBase;
        private readonly MongoDb _mongoDb;
        private readonly string _collectionName;

        public AddDocumentCommand(AddDocumentViewModel<T> documentViewModel,ViewModelBase viewModelBase, MongoDb mongoDB, string collectionName)
        {
            _documentViewModel = documentViewModel;
            _viewModelBase = viewModelBase;
            _mongoDb = mongoDB;
            _collectionName = collectionName;
            
        }

        public bool CanExecute(object? parameter) => !_viewModelBase.HasErrors;


        public void Execute(object? parameter)
        {
            _mongoDb.InsertDocument<T>(_collectionName, _documentViewModel.Document);

        }

        public event EventHandler? CanExecuteChanged;
    }
}
