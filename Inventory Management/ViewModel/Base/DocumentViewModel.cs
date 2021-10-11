using Inventory_Management.Database;

namespace Inventory_Management.ViewModel.Base
{
    public interface DocumentViewModel<T> where T : BaseEntity
    {
        T Document { get; set; }
    }
}
