namespace Food.E.Models
{
    public class CartItem
    {
        public string Id { get; set; }
        public string FoodItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
