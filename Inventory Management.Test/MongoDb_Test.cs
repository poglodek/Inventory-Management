using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management.Database;
using Inventory_Management.Model;
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
        public void MongoDb_Insert_Document_And_Remove_Should_Return_True()
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


            var removeResult = mongoDb.RemoveDocument<Item>("Items",item.Id);
            Assert.IsTrue(removeResult);
        }

        [Test]
        public void MongoDb_Get_Document_By_Id_Should_Return_True()
        {
            var mongoDb = new Mock<MongoDb>("InventoryManagement").Object;
            var item = mongoDb.GetDocumentById<Item>("Items", new Guid(@"d4c5611a-fdbe-4945-8518-40a73bf7431d"));
            Assert.AreEqual(new Guid(@"d4c5611a-fdbe-4945-8518-40a73bf7431d"), item.Id);
        }

        [Test]
        public void MongoDb_Get_Documents_Should_Return_Greater_Than_0()
        {
            var mongoDb = new Mock<MongoDb>("InventoryManagement").Object;
            var list =mongoDb.GetDocuments<Item>("Items");
            Assert.Greater(list.Count, 0);
        }
        [Test]
        public void MongoDb_Get_Documents_With_Filter_Should_Return_Greater_Than_0()
        {
            var mongoDb = new Mock<MongoDb>("InventoryManagement").Object;
            var list = mongoDb.GetDocumentsByPropertyName<Item>("Items", "Count", 10);
            Assert.Greater(list.Count, 0);
        }

        [Test]
        public void MongoDb_Update_Document_Should_Return_True()
        {
            var mongoDb = new Mock<MongoDb>("InventoryManagement").Object;
            var id = mongoDb.GetDocuments<Item>("Items").FirstOrDefault().Id;
            var item = new Item
            {
                Count = 12,
                Name = "Wooden desk",
                Price = 99.99,
                Tax = 19.0
            };
            mongoDb.UpdateDocument("Items",item,id);
        }
    }
}
