using FlooringOrderingSystem.Models.Interfaces;
using FlooringOrderingSystem.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderDisplayResponse DisplayOrder(string orderDate)
        {
            OrderDisplayResponse response = new OrderDisplayResponse();

            response.Order = _orderRepository.LoadOrder(orderDate);

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"{orderDate} did not return any valid Orders.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
    }
}
