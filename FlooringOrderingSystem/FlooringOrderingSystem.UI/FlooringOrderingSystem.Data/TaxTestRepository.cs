using FlooringOrderingSystem.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Models;

namespace FlooringOrderingSystem.Data
{
    public class TaxTestRepository : ITaxRepository
    {
        private static List<StateNamePairs> StateList;

        public TaxTestRepository()
        {
            LoadStates();
        }
        
        public StateNamePairs GetOne(string stateName)
        {
            return StateList.FirstOrDefault(s => s.StateAbbreviation == stateName || s.State == stateName);
        }

        private void LoadStates()
        {
            StateList = new List<StateNamePairs>()
            {
                new StateNamePairs("OH", "Ohio", 6.25M),
                new StateNamePairs("PA", "Pennsylvania", 6.75M),
                new StateNamePairs("MI", "Michigan", 5.75M),
                new StateNamePairs("IN", "Indiana", 6.00M),
            };
        }
    }
}
