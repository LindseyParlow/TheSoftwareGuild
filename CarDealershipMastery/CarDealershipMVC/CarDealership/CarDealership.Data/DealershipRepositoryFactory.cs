using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public class DealershipRepositoryFactory
    {
        public static IDealershipRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Mock":
                    return new DealershipRepositoryMock();
                case "Prod":
                    return new DealershipRepositoryEF();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
