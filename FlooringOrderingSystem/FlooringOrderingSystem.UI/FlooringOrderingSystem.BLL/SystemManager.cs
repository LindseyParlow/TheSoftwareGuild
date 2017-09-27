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

        public SystemManager(IOrderRepository orderRepository, IProductRepository productRepository, ITaxRepository taxRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _taxRepository = taxRepository;
        }

        public DisplayOrderResponse DisplayOrder(DateTime orderDate)
        {
            DisplayOrderResponse response = new DisplayOrderResponse();

            var ordersFromDate = _orderRepository.LoadOrders(orderDate);

            response.Orders = ordersFromDate;

            if (response.Orders == null)
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

        public void GetUpdateOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
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

        public void GetCreateOrder(Order newOrder)
        {
            _orderRepository.CreateOrder(newOrder);
        }

        public Order GetSpecificOrder(DateTime userOrderDate, int userorderNumber)
        {
            List<Order> ordersFromDate = _orderRepository.LoadOrders(userOrderDate);

            if(ordersFromDate == null)
            {
                return null;
            }
            else
            {
                var orderFromFile = ordersFromDate.FirstOrDefault(o => o.OrderNumber == userorderNumber);
                var specificOrder = new Order();

                specificOrder.Area = orderFromFile.Area;
                specificOrder.CostPerSquareFoot = orderFromFile.CostPerSquareFoot;
                specificOrder.CustomerName = orderFromFile.CustomerName;
                specificOrder.LaborCostPerSquareFoot = orderFromFile.LaborCostPerSquareFoot;
                specificOrder.OrderDate = orderFromFile.OrderDate;
                specificOrder.OrderNumber = orderFromFile.OrderNumber;
                specificOrder.ProductType = orderFromFile.ProductType;
                specificOrder.State = orderFromFile.State;
                specificOrder.TaxRate = orderFromFile.TaxRate;

                return specificOrder;
            }
        }
        public void ConfirmRemoveOrder(Order order)
        {
            _orderRepository.RemoveOrder(order);
        }
    }
}
