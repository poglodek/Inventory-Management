using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management.Model;
using Inventory_Management.ViewModel.Base;

namespace Inventory_Management.ViewModel
{
    public class ItemsViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; set; } 
        public ItemsViewModel()
        {
            Items = new ObservableCollection<Item>();
            Items.Add(new Item()
            {
                Name = "Test NameTest NameTest NameTest NameTest NameTest NameTest Name2", Count = 1, DateAdded = DateTime.Now, DateExpiration = DateTime.Now.AddDays(43),
                Price = 34.33, Tax = 17.35
            });
            OnPropertyChanged(nameof(Items));
        }
    }
}
