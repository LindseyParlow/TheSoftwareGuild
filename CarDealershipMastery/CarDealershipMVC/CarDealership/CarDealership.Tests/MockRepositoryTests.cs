using CarDealership.Data;
using CarDealership.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Tests
{
    [TestFixture]
    public class MockRepositoryTests
    {
        [Test]
        public void CanGetTop20AvailableNewVehicles()
        {
            var repo = DealershipRepositoryFactory.Create();
            
            var vehicles = repo.GetTop20NewVehicles();

            Assert.AreEqual(2, vehicles.Count);
        }
    }
}
