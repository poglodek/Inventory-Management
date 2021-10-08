using System;
using System.Collections.Generic;
using Inventory_Management.Database;

namespace Inventory_Management.Model
{
    public class Order : BaseEntity
    {
        public List<Item> Items {  get; set; }
        public Client Client {  get; set; }
        public DateTime DateOfBuy {  get; set; }
        public string Payment {  get; set; }
        public string Comments {  get; set; }
        public string Address {  get; set; }
    }
}
