using System.Collections.Generic;
using Inventory_Management.Model;

namespace Inventory_Management.Services
{
    public interface IListOrderBy
    {
        List<Item> OrderBy(List<Item> list, bool descending, string propertyName);
    }
}