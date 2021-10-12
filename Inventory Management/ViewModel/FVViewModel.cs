using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Inventory_Management.Commands;
using Inventory_Management.ViewModel.Base;

namespace Inventory_Management.ViewModel
{
    public class FVViewModel : ViewModelBase, DocumentsViewModelBase<Model.Order>
    {
        public ObservableCollection<Model.Order> Orders { get; set; }
        public FVViewModel()
        {
            Orders = new ObservableCollection<Model.Order>();
            SetList(_mongoDb.GetDocuments<Model.Order>("Orders"));
            GenerateFV = new GenerateFVCommand(this);
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

        public ICommand GenerateFV { get; set; }

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
