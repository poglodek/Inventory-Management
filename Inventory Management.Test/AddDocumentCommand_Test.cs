using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMoq;
using Inventory_Management.Commands;
using Inventory_Management.Database;
using Inventory_Management.Model;
using Inventory_Management.ViewModel.Base;
using Inventory_Management.ViewModel.Item;
using Moq;
using NUnit.Framework;

namespace Inventory_Management.Test
{
    public class AddDocumentCommand_Test
    {
        [Test]
        public void AddDocumentCommand_Test_Can_Create_Document_Should_Return_True()
        {
            var mocker = new AutoMoqer();
            var addDocummentCommand = new Mock<AddDocumentCommand<Item>>(mocker.GetMock<DocumentViewModel<Item>>().Object, mocker.GetMock<ViewModelBase>().Object, new Mock<MongoDb>("AddDocumentCommand_Test").Object, "Items");
            var result = addDocummentCommand.Object.CanExecute(null);

            Assert.IsTrue(result);
        }

    }
}
