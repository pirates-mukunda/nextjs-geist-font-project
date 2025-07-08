using System.Collections.Generic;
using System.Linq;
using Food.E.Models;

namespace Food.E.Services
{
    public class CartService
    {
        private readonly List<CartItem> _cartItems;

        public CartService()
        {
            _cartItems = new List<CartItem>();
        }

        public List<CartItem> GetCartItems()
        {
            return _cartItems;
        }

        public void AddToCart(CartItem item)
        {
            var existingItem = _cartItems.FirstOrDefault(ci => ci.FoodItemId == item.FoodItemId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                _cartItems.Add(item);
            }
        }

        public void RemoveFromCart(string itemId)
        {
            var item = _cartItems.FirstOrDefault(ci => ci.Id == itemId);
            if (item != null)
            {
                _cartItems.Remove(item);
            }
        }

        public void ClearCart()
        {
            _cartItems.Clear();
        }

        public decimal GetTotalPrice()
        {
            decimal total = 0;
            foreach (var item in _cartItems)
            {
                total += item.Price * item.Quantity;
            }
            return total;
        }
    }
}
