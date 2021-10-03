using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management.Database.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace Inventory_Management.Database.Entity
{
    public class Order : BaseEntity
    {
        public List<Item> Items {  get; set; }
        public Client Client {  get; set; }
        public DateTime DateOfBuy {  get; set; }
        public string Payment {  get; set; }
        public string Comments {  get; set; }
        public Address Address {  get; set; }
    }
}
