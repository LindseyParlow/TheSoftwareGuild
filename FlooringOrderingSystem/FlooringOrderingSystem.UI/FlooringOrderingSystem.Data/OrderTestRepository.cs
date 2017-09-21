using FlooringOrderingSystem.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Models;

namespace FlooringOrderingSystem.Data
{
    public class OrderTestRepository : IOrderRepository
    {
        private static Order _order = new Order
        {
            OrderNumber = "1",
            CustomerName = "Wise",
            State = "OH",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
            OrderDate = new DateTime(2013, 06, 01)
        };
        
        public Order LoadOrder(string OrderDate)
        {
            return _order;
        }

        public void SaveOrder(Order order)
        {
            _order = order;
        }
    }
}
