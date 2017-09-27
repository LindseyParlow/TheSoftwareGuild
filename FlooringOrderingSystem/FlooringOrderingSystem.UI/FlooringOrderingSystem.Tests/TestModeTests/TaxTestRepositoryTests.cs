using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.BLL;

namespace FlooringOrderingSystem.Tests.TestModeTests
{
    [TestFixture]
    public class TaxTestRepositoryTests
    {
        [TestCase("OH","Ohio",6.25)]
        public void GetOneTest(string stateAbbreviation, string stateName, decimal taxRate)
        {
            List<StateNamePairs> StateList = new List<StateNamePairs>() { new StateNamePairs("OH", "Ohio", 6.25M) };

            var getOnePair = StateList.FirstOrDefault(s => s.StateAbbreviation == stateName || s.State == stateName);

            getOnePair.StateAbbreviation = stateAbbreviation;
            getOnePair.State = stateName;
            getOnePair.TaxRate = taxRate;

            Assert.AreEqual(stateAbbreviation, getOnePair.StateAbbreviation);
            Assert.AreEqual(stateName, getOnePair.State);
            Assert.AreEqual(taxRate, getOnePair.TaxRate);

        }


        [TestCase("OH","Ohio",6.25)]
        public void StateNamePairsTest(string stateAbbreviation, string stateName, decimal taxRate)
        {
            SystemManager manager = new SystemManager(OrderRepositoryFactory.Create("Test"), ProductRepositoryFactory.Create("Test"), TaxRepositoryFactory.Create("Test"));
            var statePairInfo = manager.GetStateNamePairs("Ohio");
            
            Assert.AreEqual(statePairInfo.StateAbbreviation, stateAbbreviation);
            Assert.AreEqual(statePairInfo.State, stateName);
            Assert.AreEqual(statePairInfo.TaxRate, taxRate);
        }
    }
}
