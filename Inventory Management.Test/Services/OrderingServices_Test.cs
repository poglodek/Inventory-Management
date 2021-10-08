using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management.Model;
using Inventory_Management.Services;
using NUnit.Framework;

namespace Inventory_Management.Test.Services
{
    [TestFixture]
    public class OrderingServices_Test
    {
        [Test]
        public void OrderingServices_Item_OrderBy_Name_ASC_Should_Return_True()
        {
            var services = new OrderingServices();
            var list = new List<Item>()
            {
                new Item() { Name = "Wooden Chair" },
                new Item() { Name = "Metal Desk" }
            };
            var testingList = services.ItemOrderBy(list, false, "Name");

            var orderedList = new List<Item>()
            {
                new Item() { Name = "Metal Desk" },
                new Item() { Name = "Wooden Chair" }

            };
            Assert.AreEqual(orderedList.First().Name, testingList.First().Name);
        }
        [Test]
        public void OrderingServices_Item_OrderBy_Name_DESC_Should_Return_True()
        {
            var services = new OrderingServices();
            var list = new List<Item>()
            {
                new Item() { Name = "Metal Desk" },
                new Item() { Name = "Wooden Chair"}
                
            };
            var testingList = services.ItemOrderBy(list, true, "Name");

            var orderedList = new List<Item>()
            {
                new Item() { Name = "Wooden Chair" },
                new Item() { Name = "Metal Desk" }

            };
            Assert.AreEqual(orderedList.First().Name, testingList.First().Name);
        }
        [Test]
        public void OrderingServices_Item_OrderBy_Price_ASC_Should_Return_True()
        {
            var services = new OrderingServices();
            var list = new List<Item>()
            {
                new Item() { Name = "Wooden Chair", Price=13 },
                new Item() { Name = "Metal Desk", Price=10 }
            };
            var testingList = services.ItemOrderBy(list, false, "Price");

            var orderedList = new List<Item>()
            {
                new Item() { Name = "Metal Desk" ,Price=10 },
                new Item() { Name = "Wooden Chair",Price=13 }

            };
            Assert.AreEqual(orderedList.First().Name, testingList.First().Name);
        }
        [Test]
        public void OrderingServices_Item_OrderBy_TAX_ASC_Should_Return_True()
        {
            var services = new OrderingServices();
            var list = new List<Item>()
            {
                new Item() { Name = "Wooden Chair", Price=13, Tax=23.00 },
                new Item() { Name = "Metal Desk", Price=10, Tax=23.001 }
            };
            var testingList = services.ItemOrderBy(list, false, "Price");

            var orderedList = new List<Item>()
            {
                new Item() { Name = "Metal Desk" ,Price=10, Tax=23.001 },
                new Item() { Name = "Wooden Chair",Price=13, Tax=23.00 }

            };
            Assert.AreEqual(orderedList.First().Name, testingList.First().Name);
        }
        [Test]
        public void OrderingServices_Item_OrderBy_AddingDate_ASC_Should_Return_True()
        {
            var services = new OrderingServices();
            var list = new List<Item>()
            {
                new Item() { Name = "Wooden Chair", Price=13, DateAdded= DateTime.Now.AddDays(1) },
                new Item() { Name = "Metal Desk", Price=10 , DateAdded= DateTime.Now}
            };
            var testingList = services.ItemOrderBy(list, false, "Added");

            var orderedList = new List<Item>()
            {
                new Item() { Name = "Metal Desk", Price=10 , DateAdded= DateTime.Now},
                new Item() { Name = "Wooden Chair", Price=13, DateAdded= DateTime.Now.AddDays(1) }
                

            };
            Assert.AreEqual(orderedList.First().Name, testingList.First().Name);
        }
        [Test]
        public void OrderingServices_Item_OrderBy_ExpireDate_ASC_Should_Return_True()
        {
            var services = new OrderingServices();
            var list = new List<Item>()
            {
                new Item() { Name = "Wooden Chair", Price=13, DateExpiration= DateTime.Now.AddDays(1) },
                new Item() { Name = "Metal Desk", Price=10 }
            };
            var testingList = services.ItemOrderBy(list, false, "Added");

            var orderedList = new List<Item>()
            {
                new Item() { Name = "Wooden Chair", Price=13, DateExpiration= DateTime.Now.AddDays(1) },
                new Item() { Name = "Metal Desk", Price=10 }

            };
            Assert.AreEqual(orderedList.First().Name, testingList.First().Name);
        }
        [Test]
        public void OrderingServices_Item_OrderBy_ExpireDate_DESC_Should_Return_True()
        {
            var services = new OrderingServices();
            var list = new List<Item>()
            {
                new Item() { Name = "Wooden Chair", Price=13, DateExpiration= DateTime.Now.AddDays(1) },
                new Item() { Name = "Metal Desk", Price=10 }
            };
            var testingList = services.ItemOrderBy(list, true, "Added");

            var orderedList = new List<Item>()
            {
                new Item() { Name = "Metal Desk", Price=10 },
                new Item() { Name = "Wooden Chair", Price=13, DateExpiration= DateTime.Now.AddDays(1) }

            };
            Assert.AreEqual(orderedList.First().Name, testingList.First().Name);
        }

        [Test]
        public void OrderingServices_Item_SearchingParse_Should_Return_1()
        {
            var services = new OrderingServices();
            var list = new List<Item>()
            {
                new Item() { Name = "Wooden Chair", Price=13, DateExpiration= DateTime.Now.AddDays(1) },
                new Item() { Name = "Metal Desk", Price=10 }
            };
            var testingList = services.ItemSearchingParse(list,"dEsk");

            Assert.AreEqual(1, testingList.Count);
        }
        [Test]
        public void OrderingServices_Item_SearchingParse_Should_Return_0()
        {
            var services = new OrderingServices();
            var list = new List<Item>()
            {
                new Item() { Name = "Wooden Chair", Price=13, DateExpiration= DateTime.Now.AddDays(1) },
                new Item() { Name = "Metal Desk", Price=10 }
            };
            var testingList = services.ItemSearchingParse(list, "Pen");

            Assert.AreEqual(0,testingList.Count);
        }
        [Test]
        public void OrderingServices_Item_SearchingParse_Should_Return_2()
        {
            var services = new OrderingServices();
            var list = new List<Item>()
            {
                new Item() { Name = "Wooden Chair", Price=13, DateExpiration= DateTime.Now.AddDays(1) },
                new Item() { Name = "Metal Desk", Price=10 }
            };
            var testingList = services.ItemSearchingParse(list, "E");

            Assert.AreEqual(2, testingList.Count);
        }
    }
}
