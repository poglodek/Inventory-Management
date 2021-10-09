using System.Collections.Generic;
using Inventory_Management.Model;

namespace Inventory_Management.Services
{
    public interface IOrderingServices
    {
        List<Item> ItemOrderBy(List<Item> list, bool descending, string propertyName);
        List<Item> ItemSearchingParse(List<Item> list, string searchingParse);
        List<Client> ClientSearchingParse(List<Client> list, string searchingParse);
        List<Order> ClientSearchingParse(List<Order> list, string searchingParse);
    }
}