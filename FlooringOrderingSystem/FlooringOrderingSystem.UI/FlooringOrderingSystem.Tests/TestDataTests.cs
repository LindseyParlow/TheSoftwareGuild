using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Responses;

namespace FlooringOrderingSystem.Tests
{
    [TestFixture]
    public class TestDataTests
    {
        [Test]
        public void CanLoadTestData()
        {
            SystemManager manager = OrderManagerFactory.Create();

            DisplayOrderResponse response = manager.DisplayOrder("");

            Assert.IsNotNull(response.Order);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("06012013", response.Order.OrderDate);
        }
    }
}
