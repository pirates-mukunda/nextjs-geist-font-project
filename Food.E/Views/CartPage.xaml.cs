using System;
using Food.E.Services;
using Microsoft.Maui.Controls;

namespace Food.E.Views
{
    public partial class CartPage : ContentPage
    {
        private readonly CartService _cartService;

        public CartPage()
        {
            InitializeComponent();
            _cartService = new CartService();
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            CartItemsCollectionView.ItemsSource = _cartService.GetCartItems();
            TotalPriceLabel.Text = $"Total: ${_cartService.GetTotalPrice():F2}";
        }

        private void OnRemoveClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var itemId = button?.CommandParameter as string;
            if (!string.IsNullOrEmpty(itemId))
            {
                _cartService.RemoveFromCart(itemId);
                LoadCartItems();
            }
        }

        private async void OnCheckoutClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CheckoutPage());
        }
    }
}
