using Inventory_Management.Database;
using System;

namespace Inventory_Management.Model
{
    public class Stocktaking : BaseEntity
    {
        public Item Item { get; set; }
        public int CountBeforeStocktaking { get; set; }
        public int CountAfterStocktaking { get; set; }
        public double Price { get; set; }
        public double PriceDifference { get; set; }

        public DateTime Date { get; set; }
    }
}
