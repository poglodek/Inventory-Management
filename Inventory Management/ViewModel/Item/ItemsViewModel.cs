using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Windows.Input;
using Inventory_Management.Commands;
using Inventory_Management.View;
using Inventory_Management.ViewModel.Base;


namespace Inventory_Management.ViewModel.Item
{
    public class ItemsViewModel : ViewModelBase, DocumentsViewModelBase<Model.Item>
    {
        private List<Tuple<bool,string>> OrderStatus = new List<Tuple<bool, string>> ()
        {
            new(false,"Added"),
            new(true,"Added"),
            new(false,"Price"),
            new(true,"Price"),
            new(false,"Tax"),
            new(true,"Tax"),
            new(false,"Expiration"),
            new(true,"Expiration"),
            new(false,"Name"),
            new(true,"Name")
        };
        
        public ObservableCollection<Model.Item> Items { get; set; } 
        public ItemsViewModel()
        {
            Items = new ObservableCollection<Model.Item>();
            SetList(_mongoDb.GetDocuments<Model.Item>("Items"));
            RemoveItem = new RemoveDocumentCommand(this,"Items",_mongoDb);
            AddItem = new OpenNewWindowCommand("AddItem");
            EditItem = new OpenNewWindowCommand("EditItem");
            Refresh = new RelayCommand(x =>
            {
                SetList(_mongoDb.GetDocuments<Model.Item>("Items"));
            });
        }

        
        public void SetList(List<Model.Item> documents)
        {
            Items.Clear();
            foreach (var item in documents)
            {
                Items.Add(item);
            }

            OnPropertyChanged(nameof(Items));
        }
        private Model.Item selectedItem;
        public Model.Item SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        #region Commands

        public ICommand AddItem { get; set; }
        public ICommand EditItem { get; set; }
        public ICommand RemoveItem { get; set; }
        public ICommand Refresh { get; set; }


        #endregion

        private int orderByIndex;
        public int OrderByIndex
        {
            get => orderByIndex;
            set
            {
                orderByIndex = value;
                SetList(OrderingServices.ItemOrderBy(new List<Model.Item>(Items), OrderStatus[orderByIndex].Item1, OrderStatus[orderByIndex].Item2));
            }
        }
        private string searchingParse;
        public string SearchingParse
        {
            get => searchingParse;
            set
            {
                searchingParse = value;
                if(string.IsNullOrWhiteSpace(searchingParse))
                    SetList(_mongoDb.GetDocuments<Model.Item>("Items"));
                else
                    SetList(OrderingServices.ItemSearchingParse(new List<Model.Item>(Items), searchingParse));
            }
        }

    }
}
