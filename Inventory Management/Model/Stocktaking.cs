using System;
using Inventory_Management.Database;

namespace Inventory_Management.Model
{
    public class Stocktaking : BaseEntity
    {
        public Item Item {  get; set; }
        public int CountBeforeStocktaking { get; set; }
        public int CountAfterStocktaking { get; set; }
        public double Price { get; set; }
        public double PriceDifference { get; set; }

        public DateTime Date { get; set; }
    }
}
