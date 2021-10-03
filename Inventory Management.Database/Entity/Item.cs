using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Inventory_Management.Database.Entity
{
    public class Item
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Tax { get; set; }
        public int Count { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateExpiration { get; set; }
    }
}
