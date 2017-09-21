using FlooringOrderingSystem.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Models;

namespace FlooringOrderingSystem.Data
{
    public class OrderProdRepository : IOrderRepository
    {
        public Order LoadOrder(string OrderDate)
        {
            throw new NotImplementedException();
            //look at orders.txt and bring that shit in... return an order
        }

        public void SaveOrder(Order order)
        {
            throw new NotImplementedException();
            //write to order file of the correct date or make a new one if it is the first for the date
        }
    }
}
