using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using Inventory_Management.Commands;
using Inventory_Management.View;
using Inventory_Management.ViewModel.Base;

namespace Inventory_Management.ViewModel.Order
{
    public class AddOrderViewModel : ViewModelBase, DocumentViewModel<Model.Order>
    {
        public Model.Order Document { get; set; }
        public List<Model.Client> Clients {  get; set; }
        public List<Model.Item> ItemsFromDb {  get; set; }
        public ObservableCollection<Model.Item> SelectedItems {get; set;}
        public Model.Item SelectedItem {  get; set; }
        

        public AddOrderViewModel()
        {
            Clients = _mongoDb.GetDocuments<Model.Client>("Clients");
            ItemsFromDb = _mongoDb.GetDocuments<Model.Item>("Items") ;
            Document = new Model.Order();
            SelectedItems = new ObservableCollection<Model.Item>();
            DateOfBuy = DateTime.Now;
            SelectedItem = ItemsFromDb[0];

        }
        public string Payment
        {
            get => Document.Payment;
            set
            {
                ClearErrors(nameof(Payment));
                if (string.IsNullOrWhiteSpace(value))
                {
                    AddError(nameof(Payment), "Payment cannot be null.");
                }
                else
                    Document.Payment = value;
            }
        }
        public string Address
        {
            get => Document.Address;
            set
            {
                ClearErrors(nameof(Address));
                if (string.IsNullOrWhiteSpace(value))
                {
                    AddError(nameof(Address), "Address cannot be null.");
                }
                else
                    Document.Address = value;
            }
        }
        public Model.Client SelectedClient
        {
            get => Document.Client;
            set => Document.Client = value;
        }

        public string Comments
        {
            get => Document.Comments;
            set => Document.Comments = value;
        }

        private DateTime DateOfBuy
        {
            get => Document.DateOfBuy;
            set => Document.DateOfBuy = value;
        }

        private ICommand addDocument { get; set; }

        public ICommand AddDocument
        {
            get
            {
                if (addDocument is null)
                    addDocument = new RelayCommand(x =>
                    {
                        Document.Items = new List<Model.Item>(SelectedItems);
                        _mongoDb.InsertDocument("Orders", Document);
                        foreach (var item in SelectedItems)
                        {
                            var itemInDb = _mongoDb.GetDocumentById<Model.Item>("Items", item.Id);
                            itemInDb.Count -= item.Count;
                            _mongoDb.UpdateDocument<Model.Item>("Items", itemInDb, itemInDb.Id);
                        }
                    });
                return addDocument;
            }
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
