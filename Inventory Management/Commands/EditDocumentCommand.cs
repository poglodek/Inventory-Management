using Inventory_Management.Database;
using Inventory_Management.ViewModel.Base;
using System;
using System.Windows.Input;

namespace Inventory_Management.Commands
{
    public class EditDocumentCommand<T> : ICommand where T : BaseEntity
    {
        private readonly DocumentViewModel<T> _documentViewModel;
        private readonly ViewModelBase _viewModelBase;
        private readonly MongoDb _mongoDb;
        private readonly string _collectionName;

        public EditDocumentCommand(DocumentViewModel<T> documentViewModel, ViewModelBase viewModelBase, MongoDb mongoDb, string collectionName)
        {
            _documentViewModel = documentViewModel;
            _viewModelBase = viewModelBase;
            _mongoDb = mongoDb;
            _collectionName = collectionName;
        }

        public bool CanExecute(object? parameter) => !_viewModelBase.HasErrors;

        public void Execute(object? parameter)
        {
            _mongoDb.UpdateDocument<T>(_collectionName, _documentViewModel.Document, _documentViewModel.Document.Id);
        }

        public event EventHandler? CanExecuteChanged;
    }
}
