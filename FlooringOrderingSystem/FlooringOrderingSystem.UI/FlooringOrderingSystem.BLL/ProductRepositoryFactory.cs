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
    public class ProductRepositoryFactory
    {
        public static IProductRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new ProductTestRepository();
                case "Prod":
                    return new ProductProdRepository();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }

        public static IProductRepository Create(string mode)
        {
            switch (mode)
            {
                case "Test":
                    return new ProductTestRepository();
                case "Prod":
                    return new ProductProdRepository();
                default:
                    throw new Exception("Must choose either Test or Prod.");
            }
        }
    }
}
