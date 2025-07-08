using System;
using Food.E.Models;
using Food.E.Services;
using Microsoft.Maui.Controls;

namespace Food.E.Views
{
    public partial class CheckoutPage : ContentPage
    {
        private readonly OrderService _orderService;
        private readonly CartService _cartService;

        public CheckoutPage()
        {
            InitializeComponent();
            _orderService = new OrderService();
            _cartService = new CartService();
        }

        private async void OnPlaceOrderClicked(object sender, EventArgs e)
        {
            var name = NameEntry.Text;
            var address = AddressEntry.Text;
            var phone = PhoneEntry.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(phone))
            {
                await DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }

            var order = new Order
            {
                UserId = "currentUser", // Replace with actual user id
                Items = _cartService.GetCartItems()
            };

            _orderService.AddOrder(order);
            _cartService.ClearCart();

            await DisplayAlert("Success", "Your order has been placed.", "OK");
            await Navigation.PopToRootAsync();
        }
    }
}
