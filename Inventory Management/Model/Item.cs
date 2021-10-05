using System;
using Inventory_Management.Database.Entity;

namespace Inventory_Management.Model
{
    public class Item :BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Tax { get; set; }
        public int Count { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateExpiration { get; set; }
    }
}
