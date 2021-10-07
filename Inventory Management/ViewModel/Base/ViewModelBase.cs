using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Inventory_Management.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory_Management.ViewModel.Base
{
    public class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public MongoDb _mongoDb;

        public event PropertyChangedEventHandler PropertyChanged;
        private Dictionary<string, List<string>> _propertyErrors;
        
        public ViewModelBase()
        {
            _mongoDb = new MongoDb("InventoryManagement");
            _propertyErrors = new Dictionary<string, List<string>>();
        }
        protected void OnPropertyChanged(params string[] nameProperty)
        {
            foreach (var property in nameProperty)
                if (property != null) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            
        }

        
        public IEnumerable GetErrors(string? propertyName)
        {
            return _propertyErrors.GetValueOrDefault(propertyName, null);
        }

        public void ClearErrors(string propertyName)
        {
            _propertyErrors.Remove(propertyName);
        }
        public bool HasErrors
        {
            get => _propertyErrors.Any();
        }
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public void AddError(string propertyName, string errorMessage)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Add(propertyName, new List<string>());
            }
            _propertyErrors[propertyName].Add(errorMessage);
            foreach (var error in _propertyErrors)
                 foreach (var message in error.Value)
                 {
                     MessageBox.Show(message);
                 }
        }

        protected void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
