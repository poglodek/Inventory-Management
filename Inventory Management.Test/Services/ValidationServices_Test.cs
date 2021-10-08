using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management.Services;
using NUnit.Framework;

namespace Inventory_Management.Test.Services
{
    [TestFixture]
    public class ValidationServices_Test
    {

        [Test]
        [TestCase("test.test")]
        [TestCase("@test.test")]
        [TestCase("@test@test")]
        [TestCase("@test.tes@t")]
        [TestCase("testtest@")]
        [TestCase("testtest@.")]
        public void IsEmailValid_InValid_Email_Should_Return_False(string email)
        {
            var services = new ValidationServices();

            var result = services.IsEmailValid(email);
            Assert.IsFalse(result);
        }

        [Test]
        public void IsEmailValid_InValid_Email_Should_Return_True()
        {
            var services = new ValidationServices();

            var result = services.IsEmailValid("Test.test@test.com");
            Assert.IsTrue(result);
        }
    }
}
