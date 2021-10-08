using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Inventory_Management.Commands;
using Inventory_Management.ViewModel.Base;

namespace Inventory_Management.ViewModel.Client
{
    public class EditClientViewModel : ViewModelBase, DocumentViewModel<Model.Client>
    {
        public Model.Client Document { get; set; }
        public EditClientViewModel(Guid id)
        {
            Document = _mongoDb.GetDocumentById<Model.Client>("Clients", id);
            OnPropertyChanged(nameof(Document));
            EditCommand = new EditDocumentCommand<Model.Client>(this, this, _mongoDb, "Clients");
        }
        public string Name
        {
            get => Document.Name;
            set
            {
                ClearErrors(nameof(Name));
                if (string.IsNullOrWhiteSpace(value))
                {
                    AddError(nameof(Name), "Name cannot be null.");
                }
                else
                    Document.Name = value;
            }
        }
        public int NIP
        {
            get => Document.NIP;
            set => Document.NIP = value;
        }
        public int PhoneNumber
        {
            get => Document.PhoneNumber;
            set
            {
                ClearErrors(nameof(PhoneNumber));
                if (!ValidationServices.IsPhoneNumberValid(value))
                {
                    AddError(nameof(PhoneNumber), "PhoneNumber is in valid.");
                }
                else
                    Document.PhoneNumber = value;
            }
        }
        public string Email
        {
            get => Document.Email;
            set
            {
                ClearErrors(nameof(Email));

                if (!ValidationServices.IsEmailValid(value))
                {
                    AddError(nameof(Email), "Email is in valid.");
                }
                else
                    Document.Email = value;
            }
        }
        public string Address
        {
            get => Document.Address;
            set => Document.Address = value;
        }
        public ICommand EditCommand { get; set; }
    }
}
