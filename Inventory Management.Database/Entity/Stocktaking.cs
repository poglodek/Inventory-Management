using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Inventory_Management.Database.Entity
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
