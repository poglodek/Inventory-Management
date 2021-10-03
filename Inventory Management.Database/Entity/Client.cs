using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management.Database.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace Inventory_Management.Database.Entity
{
    public class Client : BaseEntity
    {
        public string Name {  get; set; }
        public int NIP {  get; set; }
        public int PhoneNumber {  get; set; }
        public string Email {  get; set; }
        public Address Address {  get; set; }
    }
}
