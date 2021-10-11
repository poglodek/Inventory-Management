using Inventory_Management.Database;
using Inventory_Management.ViewModel.Base;
using System;
using System.Windows;
using System.Windows.Input;

namespace Inventory_Management.Commands
{
    public class RemoveDocumentCommand<T> : ICommand where T : BaseEntity
    {
        private readonly DocumentsViewModelBase<T> _vm;
        private readonly string _collectionName;
        private readonly MongoDb _mongoDb;

        public RemoveDocumentCommand(DocumentsViewModelBase<T> vm, string collectionName, MongoDb mongoDb)
        {
            _vm = vm;
            _collectionName = collectionName;
            _mongoDb = mongoDb;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (_vm.SelectedItem is null) return;
            var result = MessageBox.Show("Delete this item?", "Delete", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
            if (result == MessageBoxResult.Cancel || result == MessageBoxResult.No) return;
            _mongoDb.RemoveDocumentById<T>(_collectionName, _vm.SelectedItem.Id);
            _vm.SetList(_mongoDb.GetDocuments<T>(_collectionName));
        }



        public event EventHandler? CanExecuteChanged;

    }
}
