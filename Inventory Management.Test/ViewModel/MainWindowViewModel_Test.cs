using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management.ViewModel;
using NUnit.Framework;

namespace Inventory_Management.Test.ViewModel
{
    [TestFixture]
    public class MainWindowViewModel_Test
    {
        [Test]
        public void MainWindowVM_Constructor_Should_Return_True()
        {
            var vm = new MainWindowViewModel();
            
        }
    }
}
