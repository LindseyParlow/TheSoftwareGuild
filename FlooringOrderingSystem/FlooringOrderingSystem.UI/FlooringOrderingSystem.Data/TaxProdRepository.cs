using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Data
{
    public class TaxProdRepository : ITaxRepository
    {
        private static List<StateNamePairs> StateList;

        private string taxFilePath;

        public TaxProdRepository()
        {
            taxFilePath = @"C:\Repos\bitbucket\dotnet-lindsey-parlow\FlooringOrderingSystem\FlooringOrderingSystemFiles\Taxes.txt";

            LoadStates();
        }
        
        private void LoadStates()
        {
            StateList = new List<StateNamePairs>();

            using (StreamReader sr = new StreamReader(taxFilePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');

                    string stateAbbreviation = columns[0];
                    string state = columns[1];
                    decimal taxRate = decimal.Parse(columns[2]);
                    StateNamePairs stateNamePair = new StateNamePairs(stateAbbreviation, state, taxRate);

                    StateList.Add(stateNamePair);
                }
            }
        }

        public StateNamePairs GetOne(string stateName)
        {
            return StateList.FirstOrDefault(s => s.StateAbbreviation == stateName || s.State == stateName);
        }
    }

}
