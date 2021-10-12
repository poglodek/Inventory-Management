using Inventory_Management.Model;

namespace Inventory_Management.Assets
{
    public interface IFVTempalte
    {
        string CreateFVInHtml(Order order);
    }
}