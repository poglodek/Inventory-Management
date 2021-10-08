using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Inventory_Management.Commands;
using Inventory_Management.View;
using Inventory_Management.ViewModel.Base;

namespace Inventory_Management.ViewModel.Client
{
    public class ClientsViewModel : ViewModelBase, DocumentsViewModelBase<Model.Client>
    {
        public ObservableCollection<Model.Client> Clients { get; set; }
        public ClientsViewModel()
        {
            Clients = new ObservableCollection<Model.Client>();
            SetList(_mongoDb.GetDocuments<Model.Client>("Clients"));
            RemoveClient = new RemoveDocumentCommand<Model.Client>(this, "Clients", _mongoDb);
            AddClient = new OpenNewWindowCommand("AddClient");
            EditClient = new OpenNewWindowCommand("EditClient");
            Refresh = new RelayCommand(x =>
            {
                SetList(_mongoDb.GetDocuments<Model.Client>("Clients"));
            });
        }

        public Model.Client SelectedItem { get; set; }
        public void SetList(List<Model.Client> documents)
        {
            Clients.Clear();
            foreach (var client in documents)
            {
                Clients.Add(client);
            }

            OnPropertyChanged(nameof(Clients));
        }

        #region Commands

        public ICommand AddClient { get; set; }
        public ICommand EditClient { get; set; }
        public ICommand RemoveClient { get; set; }
        public ICommand Refresh { get; set; }


        #endregion

        private string searchingParse;
        public string SearchingParse
        {
            get => searchingParse;
            set
            {
                searchingParse = value;
                if (string.IsNullOrWhiteSpace(searchingParse))
                    SetList(_mongoDb.GetDocuments<Model.Client>("Clients"));
                else
                    SetList(OrderingServices.ClientSearchingParse(new List<Model.Client>(Clients), searchingParse));
            }
        }
    }
}
