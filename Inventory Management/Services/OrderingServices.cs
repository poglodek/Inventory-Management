using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Inventory_Management.Model;

namespace Inventory_Management.Services
{
    public class OrderingServices : IOrderingServices
    {
        public List<Item> ItemOrderBy(List<Item> list, bool descending, string propertyName)
        {
            List<Item> orderedList;
            switch (propertyName)
            {
                case "Name":
                    list.Sort((x, y) => x.Name.CompareTo(y.Name));
                    orderedList = list;
                    break;
                case "Price":
                    orderedList =  list.OrderBy(x => x.Price).ToList();
                    break;
                case "Tax":
                    orderedList = list.OrderBy(x => x.Tax).ToList();
                    break;
                case "Added":
                    orderedList = list.OrderBy(x => x.DateAdded).ToList();
                    break;
                case "Expiration":
                    orderedList = list.OrderBy(x => x.DateExpiration).ToList();
                    break;
                default:
                    orderedList = list.OrderBy(x => x.Name).ToList();
                    break;
            }
            if (descending)
                orderedList.Reverse();
            return orderedList;
        }

        public List<Item> ItemSearchingParse(List<Item> list, string searchingParse)
        {
            return list.Where(x => x.Name.ToUpper().Contains(searchingParse.ToUpper())).ToList();
        }
        public List<Client> ClientSearchingParse(List<Client> list, string searchingParse)
        {
            return list.Where(x => x.Name.ToUpper().Contains(searchingParse.ToUpper())).ToList();
        }
    }
}
