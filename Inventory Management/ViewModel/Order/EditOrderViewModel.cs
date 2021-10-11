using Inventory_Management.Commands;
using Inventory_Management.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Inventory_Management.ViewModel.Order
{
    public class EditOrderViewModel : ViewModelBase, DocumentViewModel<Model.Order>
    {
        public Model.Order Document { get; set; }
        public List<Model.Item> ItemsFromDb { get; set; }
        public List<Model.Item> ItemsFromOrder { get; set; }
        public ObservableCollection<Model.Item> SelectedItems { get; set; }
        public Model.Item SelectedItem { get; set; }
        public EditOrderViewModel(Guid id)
        {
            ItemsFromDb = _mongoDb.GetDocuments<Model.Item>("Items");
            Document = _mongoDb.GetDocumentById<Model.Order>("Orders", id);
            SelectedItems = new ObservableCollection<Model.Item>(Document.Items);
            OnPropertyChanged(nameof(Document));
            ItemsFromOrder = new List<Model.Item>(Document.Items);
        }

        private ICommand editCommand;
        public ICommand EditCommand
        {
            get
            {
                if (editCommand is null)
                    editCommand = new RelayCommand(x =>
                    {
                        Document.Items = new List<Model.Item>(SelectedItems);
                        _mongoDb.UpdateDocument("Orders", Document, Document.Id);
                        UpDateItems();

                    });
                return editCommand;
            }
        }

        private void UpDateItems()
        {
            foreach (var item in SelectedItems)
            {
                var itemInDb = _mongoDb.GetDocumentById<Model.Item>("Items", item.Id);
                itemInDb.Count -= item.Count;
                _mongoDb.UpdateDocument<Model.Item>("Items", itemInDb, itemInDb.Id);
            }
            foreach (var item in ItemsFromOrder)
            {
                var itemInDb = _mongoDb.GetDocumentById<Model.Item>("Items", item.Id);
                itemInDb.Count += item.Count;
                _mongoDb.UpdateDocument<Model.Item>("Items", itemInDb, itemInDb.Id);
            }
        }
        public Model.Client Client
        {
            get => Document.Client;
            set => Document.Client = value;
        }
        public string Payment
        {
            get => Document.Payment;
            set => Document.Payment = value;
        }

        public string Comments
        {
            get => Document.Comments;
            set => Document.Comments = value;
        }

        public string Address
        {
            get => Document.Address;
            set => Document.Address = value;
        }
        private ICommand addItemToListCommand;
        public ICommand AddItemToListCommand
        {
            get
            {
                if (addItemToListCommand is null) addItemToListCommand = new RelayCommand(x =>
                {
                    AddItemToList(SelectedItems, SelectedItem);
                    OnPropertyChanged(nameof(SelectedItems));
                });
                return addItemToListCommand;
            }
        }
        private ICommand clearListCommand;
        public ICommand ClearListCommand
        {
            get
            {
                if (clearListCommand is null) clearListCommand = new RelayCommand(x =>
                {
                    SelectedItems.Clear();
                });
                return clearListCommand;
            }
        }

        private void AddItemToList(ObservableCollection<Model.Item> selectedItems, Model.Item selectedItem)
        {
            if (selectedItems.Any(x => x.Id.Equals(selectedItem.Id)))
            {
                var item = selectedItems.FirstOrDefault(x => x.Id.Equals(selectedItem.Id));
                item.Count++;
                selectedItems.Remove(item);
                selectedItems.Add(item);
            }
            else
            {
                selectedItem.Count = 1;
                selectedItems.Add(selectedItem);
            }
        }
    }
}
