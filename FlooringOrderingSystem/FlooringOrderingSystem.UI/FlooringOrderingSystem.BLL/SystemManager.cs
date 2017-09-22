using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Interfaces;
using FlooringOrderingSystem.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.BLL
{
    public class SystemManager
    {
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private ITaxRepository _taxRepository;

        public SystemManager()
        {
            _orderRepository = OrderRepositoryFactory.Create();
            _productRepository = ProductRepositoryFactory.Create();
            _taxRepository = TaxRepositoryFactory.Create();
        }

        public DisplayOrderResponse DisplayOrder(DateTime orderDate)
        {
            DisplayOrderResponse response = new DisplayOrderResponse();

            var ordersFromDate = _orderRepository.LoadOrders(orderDate);

            response.Orders = ordersFromDate;

            if (response.Orders.Count == 0)
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

        public bool ValidateProductName(string userInput)
        {
            return _productRepository.GetOne(userInput) != null;
        }

        public ProductPricePairs GetProductPricePairs(string productType)
        {
            return _productRepository.GetOne(productType);
        }

        public bool ValidateStateName(string userInput)
        {
            return _taxRepository.GetOne(userInput) != null;
        }

        public StateNamePairs GetStateNamePairs(string stateName)
        {
            return _taxRepository.GetOne(stateName);
        }
    }
}
