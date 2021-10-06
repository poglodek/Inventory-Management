using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management.Database;

namespace Inventory_Management.ViewModel.Base
{
    public interface ViewModelItemBase<T> where T : class
    {
        T SelectedItem {  get; set; }
        void GetList();
    }
}
