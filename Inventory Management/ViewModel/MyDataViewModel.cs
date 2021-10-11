using Inventory_Management.Model;
using Inventory_Management.Services;
using Inventory_Management.ViewModel.Base;
using System.Windows.Input;

namespace Inventory_Management.ViewModel
{
    public class MyDataViewModel : ViewModelBase
    {
        private readonly IConfigServices _configServices = new ConfigServices();
        private Config config;
        public MyDataViewModel()
        {
            config = _configServices.GetConfig();
        }
        public string Name
        {
            get => config.Name;
            set
            {
                ClearErrors(nameof(Name));
                if (string.IsNullOrWhiteSpace(value))
                {
                    AddError(nameof(Name), "Name cannot be null.");
                }
                else
                    config.Name = value;
            }
        }

        public string Address
        {
            get => config.Address;
            set
            {
                ClearErrors(nameof(Address));
                if (string.IsNullOrWhiteSpace(value))
                {
                    AddError(nameof(Address), "Address cannot be null.");
                }
                else
                    config.Address = value;
            }
        }
        public int NIP
        {
            get => config.Nip;
            set
            {
                ClearErrors(nameof(NIP));
                if (!ValidationServices.IsNIPValid(value))
                {
                    AddError(nameof(NIP), "Nip invalid");
                }
                else
                    config.Nip = value;
            }
        }
        public string Account
        {
            get => config.BankAccount;
            set
            {
                ClearErrors(nameof(Account));
                if (string.IsNullOrWhiteSpace(value))
                {
                    AddError(nameof(Account), "Account invalid");
                }
                else
                    config.BankAccount = value;
            }
        }

        public string Email
        {
            get => config.Email;
            set
            {
                ClearErrors(nameof(Email));

                if (!ValidationServices.IsEmailValid(value))
                {
                    AddError(nameof(Email), "Email is in valid.");
                }
                else
                    config.Email = value;
            }
        }
        public ICommand SaveData { get; set; }
    }
}
