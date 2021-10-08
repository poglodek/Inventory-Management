using System.Collections.Generic;
using Inventory_Management.Model;

namespace Inventory_Management.Services
{
    public interface IOrderingServices
    {
        List<Item> ItemOrderBy(List<Item> list, bool descending, string propertyName);
    }
}