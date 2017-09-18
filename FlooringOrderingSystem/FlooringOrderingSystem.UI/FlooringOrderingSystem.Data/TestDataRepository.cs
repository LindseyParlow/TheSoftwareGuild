using FlooringOrderingSystem.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Models;

namespace FlooringOrderingSystem.Data
{
    public class TestDataRepository : IOrderRepository
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
            MaterialCost = 515.00M,
            LaborCost = 475.00M,
            Tax = 61.88M,
            Total = 1051.88M,
            OrderDate = "06012013"
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
