using System;
using System.Collections.Generic;
using Food.E.Models;

namespace Food.E.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public Order()
        {
            Items = new List<CartItem>();
            OrderDate = DateTime.Now;
            Status = "Pending";
        }
    }
}
