using System.Collections.Generic;

namespace Inventory_Management.ViewModel.Base
{
    public interface DocumentsViewModelBase<T> where T : class
    {
        T SelectedItem { get; set; }
        void SetList(List<T> documents);
    }
}
