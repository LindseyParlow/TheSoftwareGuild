using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringOrderingSystem.BLL;

namespace FlooringOrderingSystem.Tests.ProdModeTests
{
    [TestFixture]
    public class TaxProdRepositoryTests
    {
        [TestCase("Ohio")]
        [TestCase("OH")]
        [TestCase("Michigan")]
        [TestCase("MI")]
        [TestCase("Indiana")]
        [TestCase("IN")]
        public void ValidateValidStateNamesTest(string stateName)
        {
            SystemManager manager = new SystemManager(OrderRepositoryFactory.Create("Prod"), ProductRepositoryFactory.Create("Prod"), TaxRepositoryFactory.Create("Prod"));
            var isStateNameValid = manager.ValidateStateName(stateName);

            Assert.IsTrue(isStateNameValid);

        }

        [TestCase("Minnesota")]
        [TestCase("MN")]
        [TestCase("Lindsey")]
        [TestCase("55")]
        [TestCase("")]
        public void ValidateInValidStateNamesTest(string stateName)
        {
            SystemManager manager = new SystemManager(OrderRepositoryFactory.Create("Prod"), ProductRepositoryFactory.Create("Prod"), TaxRepositoryFactory.Create("Prod"));
            var isStateNameValid = manager.ValidateStateName(stateName);

            Assert.IsFalse(isStateNameValid);

        }


        [TestCase("OH", "Ohio", 6.25)]
        [TestCase("MI", "Michigan", 5.75)]
        [TestCase("IN", "Indiana", 6.00)]
        [TestCase("PA", "Pennsylvania", 6.75)]
        public void StateNamePairsTest(string stateAbbreviation, string stateName, decimal taxRate)
        {
            SystemManager manager = new SystemManager(OrderRepositoryFactory.Create("Prod"), ProductRepositoryFactory.Create("Prod"), TaxRepositoryFactory.Create("Prod"));
            var stateNamePairInfo = manager.GetStateNamePairs(stateName);
            var stateAbbreviationPairInfo = manager.GetStateNamePairs(stateAbbreviation);

            Assert.IsNotNull(stateNamePairInfo);
            Assert.IsNotNull(stateAbbreviationPairInfo);

            Assert.AreEqual(stateAbbreviation, stateNamePairInfo.StateAbbreviation);
            Assert.AreEqual(stateName, stateNamePairInfo.State);
            Assert.AreEqual(taxRate, stateNamePairInfo.TaxRate);

            Assert.AreEqual(stateAbbreviation, stateAbbreviationPairInfo.StateAbbreviation);
            Assert.AreEqual(stateName, stateAbbreviationPairInfo.State);
            Assert.AreEqual(taxRate, stateAbbreviationPairInfo.TaxRate);
        }
    }
}
