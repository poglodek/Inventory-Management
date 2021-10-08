using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Inventory_Management.Commands;
using Inventory_Management.ViewModel.Base;

namespace Inventory_Management.ViewModel.Client
{
    public class ClientViewModel :ViewModelBase, DocumentViewModel<Model.Client>
    {
        
        public ICommand AddDocument { get; set; }
        public ClientViewModel()
        {
            Document = new Model.Client();
            AddDocument = new AddDocumentCommand<Model.Client>(this, this, _mongoDb, "Clients");
        }
        #region prop
        public Model.Client Document { get; set; }

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


        #endregion
    }
}
