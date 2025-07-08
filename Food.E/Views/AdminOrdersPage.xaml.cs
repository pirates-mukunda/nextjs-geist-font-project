using System;
using Food.E.Services;
using Microsoft.Maui.Controls;

namespace Food.E.Views
{
    public partial class AdminOrdersPage : ContentPage
    {
        private readonly RestaurantAdminService _adminService;

        public AdminOrdersPage()
        {
            InitializeComponent();
            _adminService = new RestaurantAdminService();
            LoadOrders();
        }

        private void LoadOrders()
        {
            OrdersCollectionView.ItemsSource = _adminService.GetOrders();
        }

        private async void OnUpdateStatusClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var orderId = button?.CommandParameter as string;
            if (!string.IsNullOrEmpty(orderId))
            {
                // For simplicity, toggle status between Pending and Completed
                var order = _adminService.GetOrders().Find(o => o.Id == orderId);
                if (order != null)
                {
                    var newStatus = order.Status == "Pending" ? "Completed" : "Pending";
                    _adminService.UpdateOrderStatus(orderId, newStatus);
                    LoadOrders();
                    await DisplayAlert("Status Updated", $"Order status changed to {newStatus}.", "OK");
                }
            }
        }
    }
}
