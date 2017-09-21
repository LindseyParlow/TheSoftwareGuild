using FlooringOrderingSystem.Data;
using FlooringOrderingSystem.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.BLL
{
    public class TaxRepositoryFactory
    {
        public static ITaxRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new TaxTestRepository();
                case "Prod":
                    return new TaxProdRepository();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
