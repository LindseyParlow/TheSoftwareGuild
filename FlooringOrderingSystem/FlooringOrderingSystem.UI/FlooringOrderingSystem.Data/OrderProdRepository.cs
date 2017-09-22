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
        public void CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order LoadOrders(DateTime OrderDate)
        {
            throw new NotImplementedException();
            //look at orders.txt and bring that shit in... return an order
        }

        public void RemoveOrder(int orderNumber, DateTime orderDate)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order, DateTime date)
        {
            throw new NotImplementedException();
            //write to order file of the correct date or make a new one if it is the first for the date
        }

        public void UpdateOrder(int orderNumber, DateTime orderDate)
        {
            throw new NotImplementedException();
        }

        List<Order> IOrderRepository.LoadOrders(DateTime OrderDate)
        {
            throw new NotImplementedException();
        }
    }
}
