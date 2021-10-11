using Inventory_Management.ViewModel.Base;
using System;
using System.Collections.Generic;

namespace Inventory_Management.ViewModel.Order
{
    public class OrderViewViewModel : ViewModelBase
    {
        public List<Model.Item> SelectedItems { get; set; }
        public OrderViewViewModel(Guid id)
        {
            Document = _mongoDb.GetDocumentById<Model.Order>("Orders", id);
            SelectedItems = Document.Items;
        }
        public Model.Order Document { get; set; }
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
    }
}
