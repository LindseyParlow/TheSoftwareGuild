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

        public DisplayOrderResponse DisplayOrder(string orderDate)
        {
            DisplayOrderResponse response = new DisplayOrderResponse();

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

        public bool ValidateProductName(string userInput)
        {
            return _productRepository.ProductPriceDictionary.Keys.Contains(userInput);
        }

        public ProductPricePairs GetProductPricePairs(string productType)
        {
            return _productRepository.GetProductPricePair(productType);
        }
    }
}
