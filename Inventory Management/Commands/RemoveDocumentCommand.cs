﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Inventory_Management.Database;
using Inventory_Management.Model;
using Inventory_Management.ViewModel.Base;

namespace Inventory_Management.Commands
{
    public class RemoveDocumentCommand : ICommand
    {
        private readonly DocumentsViewModelBase<Item> _vm;
        private readonly string _collectionName;
        private readonly MongoDb _mongoDb;

        public RemoveDocumentCommand(DocumentsViewModelBase<Item> vm, string collectionName, MongoDb mongoDb)
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
           _mongoDb.RemoveDocumentById<Item>(_collectionName, _vm.SelectedItem.Id);
           _vm.SetList(_mongoDb.GetDocuments<Model.Item>("Items"));
        }



        public event EventHandler? CanExecuteChanged;

    }
}
