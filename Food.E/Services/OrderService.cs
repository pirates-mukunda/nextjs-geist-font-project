using System;
using System.Collections.Generic;
using System.Linq;
using Food.E.Models;

namespace Food.E.Services
{
    public class OrderService
    {
        private readonly List<Order> _orders;

        public OrderService()
        {
            _orders = new List<Order>();
        }

        public List<Order> GetOrders()
        {
            return _orders.OrderByDescending(o => o.OrderDate).ToList();
        }

        public void AddOrder(Order order)
        {
            order.Id = Guid.NewGuid().ToString();
            order.OrderDate = DateTime.Now;
            order.Status = "Pending";
            _orders.Add(order);
        }

        public Order GetOrderById(string id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }

        public void UpdateOrderStatus(string orderId, string status)
        {
            var order = GetOrderById(orderId);
            if (order != null)
            {
                order.Status = status;
            }
        }
    }
}
