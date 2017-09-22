using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Models
{
    public class StateNamePairs
    {
        public StateNamePairs(string stateAbbreviation, string state, decimal taxRate)
        {
            StateAbbreviation = stateAbbreviation;
            State = state;
            TaxRate = taxRate;

        }

        public string StateAbbreviation { get; set; }
        public string State { get; set; }
        public decimal TaxRate { get; set; }
    }
}
