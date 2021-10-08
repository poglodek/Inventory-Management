using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Inventory_Management.Database;

namespace Inventory_Management.ViewModel.Base
{
    public interface DocumentsViewModelBase<T> where T : class
    {
        T SelectedItem {  get; set; }
        void SetList(List<T> documents);
    }
}
