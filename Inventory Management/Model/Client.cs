using Inventory_Management.Database;

namespace Inventory_Management.Model
{
    public class Client : BaseEntity
    {
        public string Name {  get; set; }
        public int NIP {  get; set; }
        public int PhoneNumber {  get; set; }
        public string Email {  get; set; }
        public string Address {  get; set; }
        public override string ToString() => $"{Name}";
    }
}
