using System.Collections.Generic;
using System.Linq;
using Food.E.Models;

namespace Food.E.Services
{
    public class RiderService
    {
        private readonly List<Order> _assignedOrders;

        public RiderService()
        {
            _assignedOrders = new List<Order>();
        }

        public List<Order> GetAssignedOrders()
        {
            return _assignedOrders;
        }

        public void AssignOrder(Order order)
        {
            if (!_assignedOrders.Any(o => o.Id == order.Id))
            {
                _assignedOrders.Add(order);
            }
        }

        public void UpdateOrderStatus(string orderId, string status)
        {
            var order = _assignedOrders.FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                order.Status = status;
            }
        }
    }
}
