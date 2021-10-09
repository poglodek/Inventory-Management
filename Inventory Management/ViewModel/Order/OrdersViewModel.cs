using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Inventory_Management.Commands;
using Inventory_Management.View;
using Inventory_Management.ViewModel.Base;

namespace Inventory_Management.ViewModel.Order
{
    public class OrdersViewModel : ViewModelBase, DocumentsViewModelBase<Model.Order>
    {
        public ObservableCollection<Model.Order> Orders { get; set; }
        public OrdersViewModel()
        {
            Orders = new ObservableCollection<Model.Order>();
            SetList(_mongoDb.GetDocuments<Model.Order>("Orders"));
            RemoveOrder = new RemoveDocumentCommand<Model.Order>(this, "Orders", _mongoDb);
            AddOrder = new OpenNewWindowCommand("AddOrder");
            EditOrder = new OpenNewWindowCommand("EditOrder");
            AboutOrder = new OpenNewWindowCommand("AboutOrder");
            Refresh = new RelayCommand(x =>
            {
                SetList(_mongoDb.GetDocuments<Model.Order>("Orders"));
            });
        }


        public Model.Order SelectedItem { get; set; }
        public void SetList(List<Model.Order> documents)
        {

            Orders.Clear();
            foreach (var order in documents)
            {
                Orders.Add(order);
            }

            OnPropertyChanged(nameof(Orders));
        }

        #region Commands

        public ICommand AddOrder { get; set; }
        public ICommand EditOrder { get; set; }
        public ICommand RemoveOrder { get; set; }
        public ICommand Refresh { get; set; }
        public ICommand AboutOrder { get; set; }


        #endregion
        private string searchingParse;
        public string SearchingParse
        {
            get => searchingParse;
            set
            {
                searchingParse = value;
                if (string.IsNullOrWhiteSpace(searchingParse))
                    SetList(_mongoDb.GetDocuments<Model.Order>("Orders"));
                else
                    SetList(OrderingServices.ClientSearchingParse(new List<Model.Order>(Orders), searchingParse));
            }
        }
    }
}
