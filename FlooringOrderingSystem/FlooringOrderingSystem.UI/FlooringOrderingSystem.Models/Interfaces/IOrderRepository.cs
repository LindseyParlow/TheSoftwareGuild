using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Models.Interfaces
{
    public interface IOrderRepository
    {
        void UpdateOrder(Order newOrder, DateTime orderDate);

        void RemoveOrder(int orderNumber, DateTime orderDate);

        void CreateOrder(Order order);

        List<Order> LoadOrders(DateTime OrderDate);
    }
}
