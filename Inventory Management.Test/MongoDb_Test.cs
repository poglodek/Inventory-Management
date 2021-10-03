using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management.Database;
using Inventory_Management.Database.Entity;
using Moq;
using NUnit.Framework;

namespace Inventory_Management.Test
{
    [TestFixture]
    public class MongoDb_Test
    {
        [Test]
        public void MongoDb_Constructor_True()
        {
            var mongoDb = new Mock<MongoDb>("InventoryManagement").Object;
        }

        [Test]
        public void MongoDb_Insert_Document_Should_Return_True()
        {
            var mongoDb = new Mock<MongoDb>("InventoryManagement").Object;
            var item = new Item
            {
                Count = 10,
                DateAdded = DateTime.Now,
                Name = "Wooden Chair",
                Price = 49.99,
                Tax = 23.0
            };
            var result = mongoDb.InsertDocument<Item>("Items", item);
            Assert.IsTrue(result);
            
        }

        [Test]
        public void MongoDb_Get_Document_By_Id_Should_Return_True()
        {
            var mongoDb = new Mock<MongoDb>("InventoryManagement").Object;
            var item = mongoDb.GetDocumentById<Item>("Items", new Guid(@"d4c5611a-fdbe-4945-8518-40a73bf7431d"));
            Assert.AreEqual(new Guid(@"d4c5611a-fdbe-4945-8518-40a73bf7431d"), item.Id);
        }
    }
}
