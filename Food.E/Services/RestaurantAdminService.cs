using System.Collections.Generic;
using System.Linq;
using Food.E.Models;

namespace Food.E.Services
{
    public class RestaurantAdminService
    {
        private readonly List<FoodItem> _menuItems;
        private readonly List<Order> _orders;

        public RestaurantAdminService()
        {
            _menuItems = new List<FoodItem>();
            _orders = new List<Order>();
        }

        public List<FoodItem> GetMenuItems()
        {
            return _menuItems;
        }

        public void AddMenuItem(FoodItem item)
        {
            _menuItems.Add(item);
        }

        public void UpdateMenuItem(FoodItem item)
        {
            var existing = _menuItems.FirstOrDefault(i => i.Id == item.Id);
            if (existing != null)
            {
                existing.Name = item.Name;
                existing.Description = item.Description;
                existing.Price = item.Price;
            }
        }

        public void RemoveMenuItem(string itemId)
        {
            var item = _menuItems.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                _menuItems.Remove(item);
            }
        }

        public List<Order> GetOrders()
        {
            return _orders;
        }

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public void UpdateOrderStatus(string orderId, string status)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                order.Status = status;
            }
        }
    }
}
