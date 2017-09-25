using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Models.Interfaces
{
    public interface IOrderRepository
    {
        void UpdateOrder(Order order);

        void RemoveOrder(Order order);

        void CreateOrder(Order order);

        List<Order> LoadOrders(DateTime OrderDate);
    }
}
