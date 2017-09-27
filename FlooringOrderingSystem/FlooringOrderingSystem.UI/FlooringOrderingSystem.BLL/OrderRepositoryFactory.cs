using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FlooringOrderingSystem.Models.Interfaces;
using FlooringOrderingSystem.Data;

namespace FlooringOrderingSystem.BLL
{
    public class OrderRepositoryFactory
    {
        public static IOrderRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new OrderTestRepository();
                case "Prod":
                    return new OrderProdRepository();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }

        public static IOrderRepository Create(string mode)
        {
            switch (mode)
            {
                case "Test":
                    return new OrderTestRepository();
                case "Prod":
                    return new OrderProdRepository();
                default:
                    throw new Exception("Must choose either Test or Prod.");
            }
        }
    }
}
