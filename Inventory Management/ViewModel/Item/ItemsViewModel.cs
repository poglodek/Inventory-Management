using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Inventory_Management.Commands;
using Inventory_Management.ViewModel.Base;


namespace Inventory_Management.ViewModel.Item
{
    public class ItemsViewModel : ViewModelBase, ViewModelItemBase<Model.Item>
    {
        public ObservableCollection<Model.Item> Items { get; set; } 
        public ItemsViewModel()
        {
            Items = new ObservableCollection<Model.Item>();
            GetList();
            RemoveItem = new RemoveDocumentCommand(this,"Items",_mongoDb);
            AddItem = new OpenNewWindowCommand("AddItem");
            EditItem = new OpenNewWindowCommand("EditItem");
            Refresh = new RelayCommand(x =>
            {
                GetList();
            });
        }

        
        public void GetList()
        {
            Items.Clear();
            var items = _mongoDb.GetDocuments<Model.Item>("Items");
            foreach (var item in items)
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

        private string orderBy;
        public string OrderBy
        {
            get => orderBy;
            set
            {

                orderBy = value;
            }
        }
    }
}
